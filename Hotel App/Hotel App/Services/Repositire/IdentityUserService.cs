using Hotel_App.Model;
using Hotel_App.Services.DTOs;
using Hotel_App.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Services.Repositire
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> userManager;

        public IdentityUserService(UserManager<ApplicationUser> manager)
        {
            userManager = manager;
        }

        public async Task<UserDto> Authenticate(LoginDataDto data)
        {
            var user = await userManager.FindByNameAsync(data.Username);

            if (await userManager.CheckPasswordAsync(user, data.Password))
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName

                };
            }

            return null;
        }

        public async Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName

                };
                
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
        }
    }
}
