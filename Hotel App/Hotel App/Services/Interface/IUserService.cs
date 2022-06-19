using Hotel_App.Services.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hotel_App.Services.Interface
{
   public interface IUserService
    {
        public Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState);
        public Task<UserDto> Authenticate(LoginDataDto data);
        public  Task<UserDto> GetUser(ClaimsPrincipal principal);
    }
}
