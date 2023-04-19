using System.Security.Claims;
using ForTEsts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ForTEsts.Services
{
    public class UserService
    {
        private readonly AvatarService _avatarService;

        public UserService(AvatarService avatarService)
        {
            _avatarService = avatarService;
        }

        public async Task<ApplicationUser> GetUser(ClaimsPrincipal user, UserManager<ApplicationUser> userManager)
        {
            return await userManager.GetUserAsync(user);
        }

        public async Task UpdateSettings(ApplicationUser model, ApplicationUser user, IFormFile file, UserManager<ApplicationUser> userManager)
        {
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Category = model.Category;
            user.Amount = model.Amount;
            
            if (file != null)
            {
                var fileName = _avatarService.UploadPhoto(file);
                user.Avatar = fileName;
            }
            
            await userManager.UpdateAsync(user);
        }
    }
}