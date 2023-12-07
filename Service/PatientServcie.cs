using Core.DTOs;
using Core.Repositories;
using Core.Enums;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

namespace Service
{
    public class PatientServcie : IPatientServcie
    {
        private readonly IPatientRepository patientRepository;

        public PatientServcie(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync(int? pageSize, int? skip, int? take)
        {
            var patientList =  await patientRepository.FindAllAsync(Role.Patient, pageSize, skip, take);
            if(patientList != null)
            {
                List<PatientDto> patients = new List<PatientDto>();
                foreach (var patient in patientList)
                {
                    PatientDto Patient = new PatientDto()
                    {
                        Id = patient.Id,
                        userName = patient.UserName,
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        Phone = patient.Phone,
                        DateOfBirth = patient.DateOfBirth,
                        Gender = patient.Gender,
                        Email = patient.Email,
                        Image = patient?.Image
                    };
                    patients.Add(Patient);
                }
                return patients;
            }
            else
            {
                return Enumerable.Empty<PatientDto>();

            }

        }

        public async Task<PatientDto> GetPatientAsync(string Id)
        {
            var existingPatient = await patientRepository.GetByIdAsync(Id, Role.Patient);

            PatientDto patient = new PatientDto()
            {
                Id = existingPatient.Id,
                userName = existingPatient.UserName,
                FirstName = existingPatient.FirstName,
                LastName = existingPatient.LastName,
                Phone = existingPatient.Phone,
                DateOfBirth = existingPatient.DateOfBirth,
                Gender = existingPatient.Gender,
                Email = existingPatient.Email,
                Image = existingPatient.Image
            };

            return patient;
        }
    }
}
