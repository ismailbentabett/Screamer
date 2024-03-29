using Screamer.Application.Models.Identity;
using Screamer.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Screamer.Application.Contracts.Presistance;
using AutoMapper;
using Screamer.Application.Dtos;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Screamer.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        private readonly IAlgoliaService _algoliaService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            IUnitOfWork uow,
            IMapper mapper,
            IAlgoliaService algoliaService
        )
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _uow = uow;
            _mapper = mapper;

            _algoliaService = algoliaService;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotFoundException($"User with {request.Email} not found.", request.Email);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(
                user,
                request.Password,
                false
            );

            if (result.Succeeded == false)
            {
                throw new BadRequestException($"Credentials for '{request.Email} aren't valid'.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };
            var users = await _uow.UserRepository.GetAllAsync();
            var userSearchDto = _mapper.Map<IEnumerable<UserSearchResult>>(users);

            await _algoliaService.AddAllUsersToIndex("user", userSearchDto);

            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                var users = await _uow.UserRepository.GetAllAsync();
                var userSearchDto = _mapper.Map<IEnumerable<UserSearchResult>>(users);

                await _algoliaService.AddAllUsersToIndex("user", userSearchDto);
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("•{0}\n", err.Description);
                }

                throw new BadRequestException($"{str}");
            }
        }

        public async Task<AuthResponse> ExternalGoogleLogin(ExternalAuthRequest request)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(request.AccessToken);

                var user = await _userManager.FindByEmailAsync(payload.Email);

                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = payload.Email,
                        Email = payload.Email,
                        FirstName = payload.GivenName,
                        LastName = payload.FamilyName
                    };

                    var result = await _userManager.CreateAsync(user);

                    if (!result.Succeeded)
                    {
                        throw new Exception("the failed one");
                    }
                }

                var signInResult = await _signInManager.ExternalLoginSignInAsync(
                    user.Email,
                    request.Provider,
                    isPersistent: false,
                    bypassTwoFactor: true
                );

                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

                var response = new AuthResponse
                {
                    Id = user.Id,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Email = user.Email,
                    UserName = user.UserName
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
            }
                .Union(userClaims)
                .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key)
            );

            var signingCredentials = new SigningCredentials(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256
            );

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;
        }

        public async Task<AuthResponse> ExternalFacebookLogin(ExternalAuthRequest request)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(
                $"https://graph.facebook.com/v12.0/me?fields=id,email,first_name,last_name&access_token={request.AccessToken}"
            );
            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            var email = json.Value<string>("email");
            var firstName = json.Value<string>("first_name");
            var lastName = json.Value<string>("last_name");

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                };

                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create user.");
                }
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(
                user.Email,
                request.Provider,
                isPersistent: false,
                bypassTwoFactor: true
            );

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var authResponse = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return authResponse;
        }
    }
}
