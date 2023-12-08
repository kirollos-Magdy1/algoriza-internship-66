using Core.Domains;
using Core.DTOs;
using Core.Enums;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
            var res = await UserManager.AddToRoleAsync(user, role.ToString());
          
            return userCreationResult;
    }

        public async Task<string> Login(LoginUserDto loginUserDto)
        {
            User user = await UserManager.FindByNameAsync(loginUserDto.UserName);

            if (user == null)
            {
                return null;
            }

            bool found = await UserManager.CheckPasswordAsync(user, loginUserDto.Password);

            if (found)
            {
                var claims = new[]
                {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

                using (var sha256 = new System.Security.Cryptography.SHA256Managed())
                {
                    byte[] keyBytes = Encoding.UTF8.GetBytes(Config["JWT:Secret"]);
                    byte[] hashedBytes = sha256.ComputeHash(keyBytes);

                    SecurityKey securityKey = new SymmetricSecurityKey(hashedBytes);
                    SigningCredentials signincred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken mytoken = new JwtSecurityToken(
                        issuer: Config["JWT:ValidIssuer"],
                        expires: DateTime.Now.AddHours(1),
                        claims: claims,
                        signingCredentials: signincred
                    );

                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    string token = tokenHandler.WriteToken(mytoken);

                    return token;
                }
            }

            return null;
        }



    }
}
