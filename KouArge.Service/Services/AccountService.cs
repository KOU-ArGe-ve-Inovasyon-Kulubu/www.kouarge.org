using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Service.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ITokenHandler _tokenHandler;
        private readonly IMailService _mailService;

        public AccountService(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _mailService = mailService;
        }

        public async Task<CustomResponseDto<AppUserDto>> Login(AppUserLoginDto appuser)
        {

            var user = await _userManager.FindByEmailAsync(appuser.Email);
            var listModel = new List<ErrorViewModel>();
            if (user == null)
            {
                listModel.Add(new ErrorViewModel() { ErrorCode = "Email", ErrorMessage = "E-Mail veya şifre yanlış." });
                listModel.Add(new ErrorViewModel() { ErrorCode = "Password", ErrorMessage = "E-Mail veya şifre yanlış." });

                return CustomResponseDto<AppUserDto>.Fail(400, listModel);//boyle bir kullanıcı mevcut degil
            }

            if (!user.IsActive)
            {
                listModel.Add(new ErrorViewModel() { ErrorCode = "Email", ErrorMessage = "E-Mail veya şifre yanlış." });
                listModel.Add(new ErrorViewModel() { ErrorCode = "Password", ErrorMessage = "E-Mail veya şifre yanlış." });
                return CustomResponseDto<AppUserDto>.Fail(200, listModel);
            }

            await _signInManager.SignOutAsync();

            if (await _userManager.IsLockedOutAsync(user))
            {
                listModel.Add(new ErrorViewModel() { ErrorCode = "Lock", ErrorMessage = "Hesabınız geçiçi olarak kilitlenmiştir." });
                return CustomResponseDto<AppUserDto>.Fail(400, listModel);

            }

            //SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, appuser.Password, false);

            var result = await _signInManager.PasswordSignInAsync(user, appuser.Password, false, false);


            if (result.Succeeded)
            {
                await _userManager.ResetAccessFailedCountAsync(user);

                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Count == 0)
                    roles = new List<string>();
                Token token = _tokenHandler.CreateAccessToken(60, roles.ToList(), user.Id);
                await UpdateRefreshToken(token, user, 60);

                var data = _mapper.Map<AppUserDto>(user);
                data.Token = token;
                return CustomResponseDto<AppUserDto>.Success(200, data);

            }
            else
            {
                await _userManager.AccessFailedAsync(user);

                int fail = await _userManager.GetAccessFailedCountAsync(user);

                if (fail == 3)
                {
                    await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(10)));
                    listModel.Add(new ErrorViewModel() { ErrorCode = "Lock", ErrorMessage = $"Hesabınız 5 başarısız girişten dolayı 10 dakika süreyle kilitlenmiştir. Lütfen daha sonra tekrar deneyiniz." });
                    return CustomResponseDto<AppUserDto>.Fail(400, listModel);
                }
                else
                {
                    listModel.Add(new ErrorViewModel() { ErrorCode = "Email", ErrorMessage = "E-Mail veya şifre yanlış." });
                    listModel.Add(new ErrorViewModel() { ErrorCode = "Password", ErrorMessage = "E-Mail veya şifre yanlış." });

                    return CustomResponseDto<AppUserDto>.Fail(400, listModel);//boyle bir kullanıcı mevcut degil
                }


            }
        }
        public async Task<CustomResponseDto<Token>> RefreshTokenLogin(GetRefreshTokenDto getRefreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == getRefreshToken.RefreshToken);

            if (user != null && user.RefreshTokenExpires > DateTime.UtcNow)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Count == 0)
                    roles = new List<string>();

                Token token = _tokenHandler.CreateAccessToken(60, roles.ToList(), user.Id);
                await UpdateRefreshToken(token, user, 60);

                var data = _mapper.Map<AppUserDto>(user);
                data.Token = token;

                return CustomResponseDto<Token>.Success(200, token);
            }
            else
                throw new UnAuthorizedException("401");
            //return CustomResponseDto<AppUserDto>.Fail(401, "UnAuthorizedException.", 1);
        }
        public async Task<CustomResponseDto<NoContentDto>> ResetPassword(ResetPasswordDto email)
        {
            var user = await _userManager.FindByEmailAsync(email.Email);

            if (user != null)
            {
                string passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                //TODO: uid yerine mail kullan
                string passwordLink = $"https://localhost/account/ResetPassword?uid={user.Id}&token={passwordToken}";

                return await _mailService.ResetPasswordMail(passwordLink, email.Email);

            }
            //TODO:Hata
            return CustomResponseDto<NoContentDto>.Success(204);
        }
        public async Task<CustomResponseDto<NoContentDto>> ResetPasswordConfirm(ResetPasswordConfirmDto data)
        {
            var user = await _userManager.FindByIdAsync(data.AppUserId);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, data.Token, data.NewPassword);

                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    return CustomResponseDto<NoContentDto>.Success(204);
                }
                else
                {
                    var listModel = new List<ErrorViewModel>();
                    foreach (var error in result.Errors)
                    {
                        listModel.Add(new ErrorViewModel() { ErrorCode = error.Code, ErrorMessage = error.Description });
                    }
                    return CustomResponseDto<NoContentDto>.Fail(400, listModel);
                }

            }
            return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "Email", ErrorMessage = $"User({data.AppUserId}) not found." });

        }

        public async Task<CustomResponseDto<AppUserDto>> Register(AppUserRegisterDto appuserRegisterDto)
        {
            var listModel = new List<ErrorViewModel>();
            if (await _userManager.Users.FirstOrDefaultAsync(x => x.StudentNumber == appuserRegisterDto.StudentNumber) != null)
            {
                listModel.Add(new ErrorViewModel() { ErrorCode = "StudentNumber", ErrorMessage = $"Öğrenci numarası {appuserRegisterDto.StudentNumber} zaten kayıtlı." });
                //return CustomResponseDto<AppUserDto>.Fail(400, $"StudentNumber({appuserRegisterDto.StudentNumber}) zaten kayıtlı.", 1);
            }

            if (await _userManager.FindByEmailAsync(appuserRegisterDto.Email) != null)
            {
                listModel.Add(new ErrorViewModel() { ErrorCode = "Email", ErrorMessage = $"Email adresi {appuserRegisterDto.Email} zaten kayıtlı." });

                //return CustomResponseDto<AppUserDto>.Fail(400, $"Email({appuserRegisterDto.Email}) zaten kayıtlı.", 2);
            }

            if (await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == appuserRegisterDto.PhoneNumber) != null)
            {
                listModel.Add(new ErrorViewModel() { ErrorCode = "PhoneNumber", ErrorMessage = $"Telefon numarası {appuserRegisterDto.PhoneNumber} zaten kayıtlı." });
                //return CustomResponseDto<AppUserDto>.Fail(400, $"PhoneNumber({appuserRegisterDto.PhoneNumber}) zaten kayıtlı.", 3);

            }


            appuserRegisterDto.IsActive = true;

            var user = _mapper.Map<AppUser>(appuserRegisterDto);

            if (appuserRegisterDto.NotificationId)
                user.NotificationId = 1;
            else
                user.NotificationId = 4;

            user.UserName = appuserRegisterDto.StudentNumber;
            var result = await _userManager.CreateAsync(user, appuserRegisterDto.Password);

            Token token = _tokenHandler.CreateAccessToken(60, new List<string>(), user.Id);
            await UpdateRefreshToken(token, user, 60);

            var data = _mapper.Map<AppUserDto>(user);
            data.Token = token;


            if (result.Succeeded)
                return CustomResponseDto<AppUserDto>.Success(201, data);
            else
            {
                foreach (var item in result.Errors)
                {
                    listModel.Add(new ErrorViewModel() { ErrorCode = item.Code, ErrorMessage = item.Description });
                }
                return CustomResponseDto<AppUserDto>.Fail(400, listModel);
            }
        }
        public async Task UpdateRefreshToken(Token token, AppUser user, int addRefreshTokenLifeTimeDays)
        {
            if (user != null)
            {
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpires = token.Expiration.AddDays(addRefreshTokenLifeTimeDays);
                token.RefreshTokenExpiration = token.Expiration.AddDays(addRefreshTokenLifeTimeDays);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new UnAuthorizedException("401");
        }
        public async Task<CustomResponseDto<NoContentDto>> ChangePassword(ChangePasswordDto data)
        {
            var decodedtoken = _tokenHandler.DecodeToken(data.Token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            var listModel = new List<ErrorViewModel>();

            if (user != null)
            {
                bool exist = await _userManager.CheckPasswordAsync(user, data.OldPassword);
                if (exist)
                {
                    if (data.OldPassword == data.NewPassword)
                        return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "NewPassword", ErrorMessage = "Yeni şifreniz eski şifrenizle aynı olamaz." }); ;

                    var result = await _userManager.ChangePasswordAsync(user, data.OldPassword, data.NewPassword);


                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);

                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, data.NewPassword, true, false);

                        return CustomResponseDto<NoContentDto>.Success(204);

                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            listModel.Add(new ErrorViewModel() { ErrorCode = error.Code, ErrorMessage = error.Description });
                        }
                        return CustomResponseDto<NoContentDto>.Fail(400, listModel);
                    }

                }
                else
                {
                    listModel.Add(new ErrorViewModel() { ErrorCode = "OldPassword", ErrorMessage = "Şifreniz yanlış" });
                    return CustomResponseDto<NoContentDto>.Fail(400, listModel);
                }
            }

            listModel.Add(new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = "Kullanıcı bulunamadı" });
            return CustomResponseDto<NoContentDto>.Fail(400, listModel);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteUser(string Token)
        {
            var decodedtoken = _tokenHandler.DecodeToken(Token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
                return CustomResponseDto<NoContentDto>.Success(204);
            }
            return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = "Kullanıcı bulunamadı" });

        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteUser(string Token)
        {
            var decodedtoken = _tokenHandler.DecodeToken(Token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                user.IsActive = false;
                await _userManager.UpdateAsync(user);
                return CustomResponseDto<NoContentDto>.Success(204);
            }
            return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = "Kullanıcı bulunamadı" });

        }
    }
}
