using KouArge.Core.DTOs;

namespace KouArge.Core.Services
{
    public interface IMailService
    {
        Task<CustomResponseDto<NoContentDto>> ResetPasswordMail(string link, string email);
        Task<CustomResponseDto<NoContentDto>> SendContactMail(ContactUsDto data);

    }
}
