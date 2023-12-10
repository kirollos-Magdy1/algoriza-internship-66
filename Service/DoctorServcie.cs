using Core.Domains;
using Core.DTOs;
using Core.Enums;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Service
{
    public class DoctorServcie : IDoctorServcie
    {

        private readonly IDoctorRepository doctorRepository;

        public DoctorServcie(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<DoctorAppointmentsDto>> GetAllDoctorsAppointmentAsync(int? pageSize, int? skip, int? take, string? search)
        {
            var doctorList = await doctorRepository.FindAllAsync(Role.Doctor, pageSize, skip, take, search: search);

            if (doctorList != null)
            {
                List<DoctorAppointmentsDto> doctors = new List<DoctorAppointmentsDto>();
                foreach (var doctor in doctorList)
                {
                    DoctorAppointmentsDto Doctor = new DoctorAppointmentsDto()
                    {
                        Id = doctor.Id,
                        UserName = doctor.UserName,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        Phone = doctor.Phone,
                        DateOfBirth = doctor.DateOfBirth,
                        Gender = doctor.Gender,
                        Email = doctor.Email,
                        Image = doctor.Image,
                        SpecializationId = doctor.SpecializationId,
                        Specialization = doctor.Specialization,
                        Times = new Dictionary<int, List<string>>()
                    };

                    foreach (var appointmentDay in doctor.AppointmentDays)
                    {
                        var appointmentHours = appointmentDay.AppointmentHours;
                        foreach (var appointmentHour in appointmentHours)
                        {
                            Doctor.Times[appointmentHour.Id] = new List<string>
                                {
                                    appointmentDay.Day.ToString(), appointmentHour.Time
                                };
                        }
                    }

                    doctors.Add(Doctor);
                }
                return doctors;
            }
            else
            {
                return Enumerable.Empty<DoctorAppointmentsDto>();
            }
        }


        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync(int? pageSize, int? skip, int? take)
        {
            var doctorList = await doctorRepository.FindAllAsync(Role.Doctor, pageSize, skip, take);
            if (doctorList != null)
            {
                List<DoctorDto> doctors = new List<DoctorDto>();
                foreach (var doctor in doctorList)
                {
                    Console.WriteLine($"User Id: {doctor.Id}, SpecializationId: {doctor.SpecializationId}, Specialization: {doctor.Specialization?.Name}");


                    DoctorDto Doctor = new DoctorDto()
                    {
                        Id = doctor.Id,
                        UserName = doctor.UserName,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        Phone = doctor.Phone,
                        DateOfBirth = doctor.DateOfBirth,
                        Gender = doctor.Gender.ToString(),
                        Email = doctor.Email,
                        Image = doctor.Image,
                        SpecializationId = doctor.SpecializationId,
                        Specialization = doctor.Specialization
                    };

                    doctors.Add(Doctor);
                }
                return doctors;
            }
            else
            {
                return Enumerable.Empty<DoctorDto>();

            }
        }

        public async Task<DoctorDto> GetDoctorAsync(string Id)
        {
            var existingDoctor = await doctorRepository.GetByIdAsync(Id, Role.Doctor);

            DoctorDto doctor = new DoctorDto()
            {
                Id = existingDoctor.Id,
                UserName = existingDoctor.UserName,
                FirstName = existingDoctor.FirstName,
                LastName = existingDoctor.LastName,
                Phone = existingDoctor.Phone,
                DateOfBirth = existingDoctor.DateOfBirth,
                Gender = existingDoctor.Gender.ToString(),
                Email = existingDoctor.Email,
                Image = existingDoctor.Image,
                Specialization = existingDoctor.Specialization
            };

            return doctor;

        }

        public async Task<bool> UpdateDoctorAsync(string Id, UpdateDoctorDto doctor)
        {
            var existingDoctor = await doctorRepository.GetByIdAsync(Id.ToString(), Role.Doctor);

            if (existingDoctor == null)
            {
                return false;
            }

            existingDoctor.FirstName = doctor.FirstName;
            existingDoctor.LastName = doctor.LastName;
            existingDoctor.Phone = doctor.Phone;
            existingDoctor.DateOfBirth = doctor.DateOfBirth;
            existingDoctor.Email = doctor.Email;
            existingDoctor.Image = doctor.Image;

            var result = await doctorRepository.UpdateAsync(existingDoctor);

            return result != null;

        }

        public async Task<bool> DeleteDoctorAsync(string id)
        {
            var existingDoctor = await doctorRepository.GetByIdAsync(id.ToString(), Role.Doctor);

            if (existingDoctor == null)
            {
                return false;
            }

            var result = await doctorRepository.DeleteAsync(id);

            return result != null;

        }

        public async Task<bool> AddDoctorVisitPrice(string doctorId, decimal price)
        {
            var existingDoctor = await doctorRepository.GetByIdAsync(doctorId, Role.Doctor);

            if (existingDoctor == null)
            {
                return false;
            }

            existingDoctor.Price = price;

            var result = await doctorRepository.UpdateAsync(existingDoctor);

            return result != null;

        }
       
    }
}
