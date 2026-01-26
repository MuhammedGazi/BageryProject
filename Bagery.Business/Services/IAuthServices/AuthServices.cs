using Bagery.Business.Constants;
using Bagery.Business.DTOs.AuthDTOs;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Services.IAuthServices
{
    public class AuthServices(UserManager<AppUser> _userManager,
                              SignInManager<AppUser> _signInManager,
                              ICloudinaryService _cloudinaryService,
                              ILogger<AuthServices> _logger) : IAuthServices
    {
        public async Task<IResult> LoginAsync(LoginDto dto)
        {

            try
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);

                if (user == null)
                {
                    _logger.LogError(Messages.UserNotFound, dto.Email);
                    return new ErrorResult(Messages.UserNotFound);
                }

                if (!user.IsActive)
                {
                    _logger.LogError(Messages.UserIsActiveFalse, dto.Email);
                    return new ErrorResult(Messages.UserIsActiveFalse);
                }

                var signInResult = await _signInManager.PasswordSignInAsync(user, dto.Password, isPersistent: false, lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    user.LastLoginDate = DateTime.Now;
                    await _userManager.UpdateAsync(user);
                }
                else
                {
                    return new ErrorResult(Messages.UserExisting);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new SuccessResult(Messages.UserLogingSuccess);
        }

        public async Task<IResult> LogoutAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new SuccessResult(Messages.UserLogOutSuccess);
        }

        public async Task<IResult> RegisterAsync(RegisterDto dto)
        {
            try
            {
                //kullanıcı daha önce var mı diye kontrol ediyoruz
                var existingUser = await _userManager.FindByEmailAsync(dto.Email);
                if (existingUser != null)
                {
                    _logger.LogError(Messages.UserExisting, dto.Email);
                    return new ErrorResult(Messages.UserExisting);
                }

                var user = new AppUser
                {
                    UserName = dto.Email,
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                if (dto.ProfileImage != null)
                {
                    var uploadResult = await _cloudinaryService.UploadImageAsync(dto.ProfileImage, "profiles");
                    if (uploadResult.Success)
                    {
                        user.ProfileImagePublicId = uploadResult.PublicId;
                        user.ProfileImageUrl = uploadResult.SecureUrl;
                    }
                }

                var createResult = await _userManager.CreateAsync(user, dto.Password);
                if (createResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
                else
                {
                    _logger.LogError(createResult.Errors.Select(e => e.Description).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new SuccessResult(Messages.UserAdded);
        }
    }
}
