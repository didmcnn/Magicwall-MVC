using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace CoreLayer.Utilities.MailUtilities
{
    public class MailManager : IMailService
    {
        readonly IConfiguration _configuration;

        public MailManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendMailAsync(string mail, string subject, string message)
        {
            var client = new SmtpClient
            {
                Host = _configuration["MailInfo:Host"],
                Port = int.Parse(_configuration["MailInfo:Port"]),
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_configuration["MailInfo:Mail"], _configuration["MailInfo:Password"])
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["MailInfo:Mail"]),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(mail);

            try
            {
                await client.SendMailAsync(mailMessage);
                Console.WriteLine("Email sent successfully.");
                return true;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> SendMailsAsync(string[] mail, string subject, string message)
        {
            for (int i = 0; i < mail.Length; i++)
            {
                try
                {
                    await SendMailAsync(mail[i], subject, message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                    throw;
                }
            }
            return true;
        }

    }
}
