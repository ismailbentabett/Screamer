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

            return Redirect("http://localhost:4200/v/settings/auth");
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return Ok();
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                /*    var callbackUrl = Url.Action(
                       "ResetPassword",
                       "Auth",
                       new { code },
                       protocol: HttpContext.Request.Scheme
                   ); */

                //i want lo took like this localhost http://localhost:4200/v/settings/account/reset-password?code=code?email=email

                var callbackUrl =
                    $"http://localhost:4200/auth/reset-password?code={code}&email={model.Email}";

                // Send email with callback URL
                await _emailSender.SendResetPasswordEmailAsync(model.Email, callbackUrl);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    // Don't reveal that the user does not exist
                    return Ok();
                }

                var result = await _userManager.ResetPasswordAsync(
                    user,
                    model.Code,
                    model.Password
                );

                if (result.Succeeded)
                {
                    return Ok();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return NotFound(
                        $"Unable to load user with ID '{_userManager.GetUserId(User)}'."
                    );
                }

                var result = await _userManager.ChangePasswordAsync(
                    user,
                    model.OldPassword,
                    model.NewPassword
                );

                if (result.Succeeded)
                {
                    return Ok();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
