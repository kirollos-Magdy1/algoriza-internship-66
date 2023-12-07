using Core.DTOs;
using Core.Enums;
using Core.Services;
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
    }
}
