using Core.DTOs;
using Core.Enums;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace algoriza_internship_66.API.Controllers
{
        [Route("api/[controller]/[action]")]
        public class AuthController: Controller
        {
            private IAccountService accountService;

            public AuthController(IAccountService accountService)
            {
                this.accountService = accountService;
            }

            [HttpPost("")]
            public async Task<IActionResult> RegisterDoctor([FromBody] RegisterPatientDto registerDoctortDto ) {

                try
                {
                    var RegisterResult =  await accountService.Register(registerDoctortDto, Role.Doctor);
                
                    return (RegisterResult.Succeeded) ? Ok(true) : BadRequest("Could not create the account" + RegisterResult.Errors.FirstOrDefault().Description);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

            [HttpPost("")]
            public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientDto registerPatientDto)
            {

                try
                {
                    var RegisterResult = await accountService.Register(registerPatientDto, Role.Patient);

                    return (RegisterResult.Succeeded) ? Ok(true) : BadRequest("Could not create the account" + RegisterResult.Errors.FirstOrDefault().Description);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }


            [HttpPost("")]
            public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
            {

                try
                {
                    var token = await accountService.Login(loginUserDto);
                    if (token != null)
                        return Ok(token);
                    else
                        return BadRequest("Invalid login");

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

            [HttpGet("")]
            [Authorize]
            public IActionResult TestJwt()
            {
                return Ok(true);

            }

        //var userId = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        //var response = new
        //{
        //    Message = "JWT Token is valid",
        //    UserId = userId
        //};

        //return Ok(response);





    }
}
