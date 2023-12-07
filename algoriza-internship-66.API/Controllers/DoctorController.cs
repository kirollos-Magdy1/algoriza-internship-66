using Core.DTOs;
using Core.Enums;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace algoriza_internship_66.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DoctorController: Controller
    {
        private IDoctorService doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDoctor(int Id)
        {
            try
            {
                var isDeleted = await doctorService.DeleteDoctor(Id);
                return (isDeleted) ? Ok(true) : BadRequest("Could not deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> DeactivateDoctor(int Id)
        {
            try
            {
                var isDeactivated = await doctorService.DeactivateDoctor(Id);
                return (isDeactivated) ? Ok(true) : BadRequest("Could not deactivate");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateDoctor(int Id, [FromBody] UpdateDoctorDto updateDoctorDto)
        {
            try
            {
                var isUpdated = await doctorService.UpdateDoctor(Id, updateDoctorDto);
                return (isUpdated) ? Ok(true) : BadRequest("Could not update");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctors = await doctorService.GetAllDoctorsAsync();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetDoctor(int Id)
        {
            try
            {
                var doctors = await doctorService.GetAllDoctorsAsync();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] AddDoctorDto addDoctorDto)
        {
            try
            {
                var NewDoctor = await doctorService.AddDoctorAsync(addDoctorDto);

                if (NewDoctor != null)
                {
                    return Ok(true);
                }
                else { return BadRequest(false); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}