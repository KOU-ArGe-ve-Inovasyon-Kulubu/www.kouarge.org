using KouArge.Core.DTOs;
using KouArge.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace KouArge.Service.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configruation;

        public MailService(IConfiguration configruation)
        {
            _configruation = configruation;
        }

        public async Task<CustomResponseDto<NoContentDto>> ResetPasswordMail(string link, string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(_configruation["AccountMail:Smtp"]);

                mail.From = new MailAddress(_configruation["AccountMail:Mail"]);
                mail.To.Add(email);
                mail.Subject = $"www.kouarge.org::Şifre sıfırlama";
                mail.Body = "<H2>Şifrenizi yenilemek için lütfen aşağıdaki linke tıklayınız.<H2><hr>";
                mail.Body += $"<a href={link}>Şifremi yenile</a>";
                smtpClient.Port = 587;
                mail.IsBodyHtml = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(_configruation["AccountMail:Mail"], _configruation["AccountMail:Password"]);
                await smtpClient.SendMailAsync(mail);

                return CustomResponseDto<NoContentDto>.Success(204);

            }
            catch (Exception _)
            {
                return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "Email", ErrorMessage = _.Message.ToString() });
            }
        }
        public async Task<CustomResponseDto<NoContentDto>> SendContactMail(ContactUsDto data)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(_configruation["ContactMail:Smtp"]);

                mail.From = new MailAddress(_configruation["ContactMail:Mail"]);
                mail.To.Add(_configruation["ContactMail:Mail"]);
                mail.Subject = $"{data.Subject}";
                mail.Body = $"Ad Soyad: {data.Name}<br>Mail: {data.Email} <br>Mesaj: {data.Message}";

                smtpClient.Port = 587;
                mail.IsBodyHtml = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(_configruation["ContactMail:Mail"], _configruation["ContactMail:Password"]);
                await smtpClient.SendMailAsync(mail);

                return CustomResponseDto<NoContentDto>.Success(204);

            }
            catch (Exception _)
            {
                return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "Email", ErrorMessage = _.Message.ToString() });
            }
        }
    }
}
