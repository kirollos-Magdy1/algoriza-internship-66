using Core.DTOs;
using Core.Enums;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace algoriza_internship_66.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DoctorController: Controller
    {
        private IDoctorServcie doctorService;

        public DoctorController(IDoctorServcie doctorService)
        {
            this.doctorService = doctorService;

        }

        [HttpGet]
        public async Task<IActionResult> SearchForDoctors(int? pageSize, int? skip, int? take, [FromQuery] string? search)
        {
            try
            {
                var doctors = await doctorService.GetAllDoctorsAppointmentAsync(pageSize, skip, take,search);
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors(int? pageSize, int? skip, int? take)
        {
            try
            {
                var doctors = await doctorService.GetAllDoctorsAsync(pageSize, skip, take);
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetDoctor(string Id)
        {
            try
            {
                var doctor = await doctorService.GetDoctorAsync(Id);
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


       

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateDoctor(string Id, [FromBody] UpdateDoctorDto updateDoctorDto)
        {
            try
            {
                var isUpdated = await doctorService.UpdateDoctorAsync(Id, updateDoctorDto);
                return (isUpdated) ? Ok(true) : BadRequest("Could not update");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDoctor(string Id)
        {
            try
            {
                var isDeleted = await doctorService.DeleteDoctorAsync(Id);
                return (isDeleted) ? Ok(true) : BadRequest("Could not deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }







    }
}