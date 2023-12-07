using Core.Domains;
using Core.DTOs;
using Core.Enums;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        public UserManager<User> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public IConfiguration Config { get; }

        public AccountService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration config)
        
        {
            UserManager = userManager;
            RoleManager = roleManager;
            Config = config;
        }
        public async Task<IdentityResult> Register(RegisterDTO registerDto, Role role)
        {
            User user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Phone = registerDto.Phone,
                DateOfBirth = registerDto.DateOfBirth,
                Image = (registerDto as RegisterDoctorDto)?.Image ?? (registerDto as RegisterPatientDto)?.Image,
                SpecializationId = (registerDto as RegisterDoctorDto)?.SpecializationId ?? null

            };

            IdentityResult userCreationResult = await UserManager.CreateAsync(user, registerDto.Password);
            //await UserManager.AddToRoleAsync(user, role.ToString());
            await UserManager.AddToRoleAsync(user, role.ToString());


            return userCreationResult;
    }

    public Task Login(LoginUserDto userDto)
        {
            throw new NotImplementedException();
        }

    
    }
}
