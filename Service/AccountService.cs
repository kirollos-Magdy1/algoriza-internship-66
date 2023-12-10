using Core.Domains;
using Core.DTOs;
using Core.Enums;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            if ((registerDto as RegisterDoctorDto)?.SpecializationId < 1)
                return IdentityResult.Failed(new IdentityError { Description = "Invalid Specialization id" });

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
            
                //check - create token
                User user = await UserManager.FindByNameAsync(loginUserDto.UserName);
                if (user != null)//user name found
                {
                    bool found = await UserManager.CheckPasswordAsync(user, loginUserDto.Password);
                    if (found)
                    {
                        //Claims Token
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        //get role
                        var roles = await UserManager.GetRolesAsync(user);
                        foreach (var itemRole in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, itemRole));
                        }
                        SecurityKey securityKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["JWT:Secret"]));

                        SigningCredentials signincred =
                            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        //Create token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            issuer: Config["JWT:ValidIssuer"],
                            audience: Config["JWT:ValidAudiance"],
                            claims: claims,
                            expires: DateTime.Now.AddHours(10),
                            signingCredentials: signincred
                            );
                        
                            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                          string token = tokenHandler.WriteToken(mytoken);
                    return token; 
                    }
                return null;
                }
                return null;

            }
        }



    }

