using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Email;
using Screamer.Application.Contracts.Identity;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Models.Identity;
using Screamer.Identity.Models;
using Screamer.Presistance.DatabaseContext;

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly ScreamerDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _uow;
        private readonly IEmailSender _emailSender;

        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(
            IAuthService authenticationService,
            ScreamerDbContext dbcontext,
            SignInManager<ApplicationUser> signInManager,
            IUnitOfWork uow,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender
        )
        {
            this._authenticationService = authenticationService;
            this._context = dbcontext;
            this._signInManager = signInManager;
            this._uow = uow;
            this._userManager = userManager;
            this._emailSender = emailSender;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [AllowAnonymous]
        [HttpPost("external/google")]
        public async Task<IActionResult> ExternalGoogleLogin([FromBody] ExternalAuthRequest request)
        {
            // Perform external login
            var response = await _authenticationService.ExternalGoogleLogin(request);

            // Return the authentication response
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("external/facebook")]
        public async Task<IActionResult> ExternalFacebookLogin(
            [FromBody] ExternalAuthRequest request
        )
        {
            // Perform external login
            var response = await _authenticationService.ExternalFacebookLogin(request);

            // Return the authentication response
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }

        /*  [HttpPost("verify")]
         public async Task<IActionResult> Verify(string token)
         {
             var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);
             if (user == null)
             {
                 return BadRequest("Invalid token.");
             }
 
             user.VerifiedAt = DateTime.Now;
             await _context.SaveChangesAsync();
 
             return Ok("User verified! :)");
         }
 
         [HttpPost("forgot-password")]
         public async Task<IActionResult> ForgotPassword(string email)
         {
             var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
             if (user == null)
             {
                 return BadRequest("User not found.");
             }
 
             user.PasswordResetToken = CreateRandomToken();
             user.ResetTokenExpires = DateTime.Now.AddDays(1);
             await _context.SaveChangesAsync();
 
             return Ok("You may now reset your password.");
         }
 
         [HttpPost("reset-password")]
         public async Task<IActionResult> ResettPassword(ResetPasswordRequest request)
         {
             var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
             if (user == null || user.ResetTokenExpires < DateTime.Now)
             {
                 return BadRequest("Invalid Token.");
             }
 
             CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
 
             user.PasswordHash = Encoding.Default.GetString(passwordHash);
             user.PasswordSalt = passwordSalt;
             user.PasswordResetToken = null;
             user.ResetTokenExpires = null;
 
             await _context.SaveChangesAsync();
 
             return Ok("Password successfully reset.");
         }
 
         private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
         {
             using (var hmac = new HMACSHA512())
             {
                 passwordSalt = hmac.Key;
                 passwordHash = hmac
                     .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
             }
         }
 
         private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
         {
             using (var hmac = new HMACSHA512(passwordSalt))
             {
                 var computedHash = hmac
                     .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                 return computedHash.SequenceEqual(passwordHash);
             }
         }
 
         private string CreateRandomToken()
         {
              return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
         }*/

        [HttpPost("send-verification-email")]
        public async Task<IActionResult> SendVerificationEmail(
            [FromBody] SendVerificationEmailRequest request
        )
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Auth",
                new { userId = user.Id, code = token },
                protocol: HttpContext.Request.Scheme
            );

            // Log the callback URL
            Console.WriteLine(
                $"Token {token} User {user.Id} requested to verify their email. Callback URL: {callbackUrl}"
            );

            var sendResult = await _emailSender.SendVerificationEmailAsync(
                request.Email,
                callbackUrl
            );

            return Ok(sendResult);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Account/ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("User ID and code are required.");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound($"User with ID '{userId}' not found.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);

            Console.WriteLine(result);
            if (result.Succeeded)
            {
                return Ok("Email confirmed successfully.");
            }
            else
            {
                return BadRequest($"Error confirming email for user with ID '{userId}'.");
            }
        }
    }
}
