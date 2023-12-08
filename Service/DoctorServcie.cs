﻿using Core.Domains;
using Core.DTOs;
using Core.Enums;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                        Gender = doctor.Gender,
                        Email = doctor.Email,
                        Image = doctor.Image,
                        SpecializationId = doctor.SpecializationId,
                        Specialization = doctor.Specialization
                        //Specialization = new SpecializationDto doctor.Specialization
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
                Gender = existingDoctor.Gender,
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
            //var existingDoctor = await doctorRepository.GetByIdAsync(id.ToString(), Role.Doctor);
                

            //if (existingDoctor == null)
            //{
            //    return false;
            //}

            var result = await doctorRepository.DeleteAsync(id);

            return result != null;


        }


    }
}
