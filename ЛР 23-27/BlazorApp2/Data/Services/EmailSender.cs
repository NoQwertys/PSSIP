using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

public class EmailSender : IEmailSender
{
    private readonly SmtpSettings _smtpSettings;

    public EmailSender(IConfiguration configuration)
    {
        _smtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        using (var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
        {
            client.Credentials = new NetworkCredential(
                _smtpSettings.Username,
                _smtpSettings.Password
            );
            client.EnableSsl = true;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.FromEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);
        }
    }
}

public class SmtpSettings
{
    public string Server { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FromEmail { get; set; }
}