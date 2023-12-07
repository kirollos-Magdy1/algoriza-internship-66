using Core.DTOs;
using Core.Enums;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace algoriza_internship_66.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PatientController : Controller
    {
        private readonly IPatientServcie patientService;
        
        public PatientController(IPatientServcie patientService)
        {
            this.patientService = patientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients(int? pageSize, int? skip, int? take)
        {
            try
            {
                var patients = await patientService.GetAllPatientsAsync(pageSize, skip, take);
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetPatient(string Id)
        {
            try
            {
                var patient = await patientService.GetPatientAsync(Id);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}