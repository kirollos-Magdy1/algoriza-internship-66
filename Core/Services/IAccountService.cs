using Core.DTOs;
using Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAccountService
    {
        Task Login(LoginUserDto userDto);
        public Task<IdentityResult> Register(RegisterDTO registerDto, Role role);
    }
}
