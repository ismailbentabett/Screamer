using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Screamer.Application.Contracts.Email;
using Screamer.Application.Models.Email;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Screamer.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message = MailHelper.CreateSingleEmail(
                from,
                to,
                email.Subject,
                email.Body,
                email.Body
            );
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SendVerificationEmailAsync(string email, string callbackUrl)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var from = new EmailAddress(_emailSettings.FromAddress, _emailSettings.FromName);
            var to = new EmailAddress(email);
            var subject = "Email Verification";

            var htmlContent =
                $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <title>Email Verification</title>
</head>
<body style='font-family: Arial, sans-serif; margin: 0; padding: 0;'>
    <table style='width: 100%; max-width: 600px; margin: 0 auto; background-color: #f4f4f4;'>
        <tr>
            <td style='padding: 20px;'>
                <table style='width: 100%; background-color: #ffffff; padding: 20px; border-radius: 5px;'>
                    <tr>
                        <td>
                            <h2 style='text-align: center;'>Email Verification</h2>
                        </td>
                    </tr>
                    <tr>
                        <td style='padding: 20px;'>
                            <p>Thank you for registering with our website. To complete your registration, please click the button below to verify your email address.</p>
                        </td>
                    </tr>
                    <tr>
                        <td style='text-align: center;'>
                            <a href='{callbackUrl}' target='_blank' style='display: inline-block; padding: 10px 20px; background-color: #007bff; color: #fff; text-decoration: none; border-radius: 4px;'>Verify Email</a>
                        </td>
                    </tr>
                    <tr>
                        <td style='padding: 20px;'>
                            <p>If the button above does not work, you can also copy and paste the following URL into your web browser:</p>
                            <p>{callbackUrl}</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>";

            var plainTextContent =
                $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <title>Email Verification</title>
</head>
<body style='font-family: Arial, sans-serif; margin: 0; padding: 0;'>
    <table style='width: 100%; max-width: 600px; margin: 0 auto; background-color: #f4f4f4;'>
        <tr>
            <td style='padding: 20px;'>
                <table style='width: 100%; background-color: #ffffff; padding: 20px; border-radius: 5px;'>
                    <tr>
                        <td>
                            <h2 style='text-align: center;'>Email Verification</h2>
                        </td>
                    </tr>
                    <tr>
                        <td style='padding: 20px;'>
                            <p>Thank you for registering with our website. To complete your registration, please click the button below to verify your email address.</p>
                        </td>
                    </tr>
                    <tr>
                        <td style='text-align: center;'>
                            <a href='{callbackUrl}' target='_blank' style='display: inline-block; padding: 10px 20px; background-color: #007bff; color: #fff; text-decoration: none; border-radius: 4px;'>Verify Email</a>
                        </td>
                    </tr>
                    <tr>
                        <td style='padding: 20px;'>
                            <p>If the button above does not work, you can also copy and paste the following URL into your web browser:</p>
                            <p>{callbackUrl}</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>";

            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent,
                htmlContent
            );
            var response = await client.SendEmailAsync(msg);
            return response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.Accepted;
        }
    }
}
