using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Security.Claims;

namespace algoriza_internship_66.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AppointmentController: Controller
    {
        private IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpPost]
        [Authorize(Roles ="Doctor")]
        public async Task<IActionResult> CreateAppointment([FromBody] AddAppointmentDto appointmentDto)
        {
            //return Ok(appointmentDto);
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            try
            {
                var isCreated = await appointmentService.AddAppointmentAsync(appointmentDto, userId.ToString());
                return (isCreated) ? Ok(true) : BadRequest("Could not deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    } 
}
