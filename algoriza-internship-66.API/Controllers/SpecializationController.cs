using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace algoriza_internship_66.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SpecializationController: Controller
    {
        private readonly ISpecializationService specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            this.specializationService = specializationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSpecializations()
        {
            try
            {
                var coupons = await specializationService.GetAllSpecializationsAsync();
                return Ok(coupons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}


