using Core.Domains;
using Core.DTOs;
using Core.Enums;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentDayRepository appointmentDayRepository;
        private readonly IAppointmentHourRepository appointmentHourRepository;
        private readonly IDoctorServcie doctorServcie;



        public AppointmentService(IAppointmentDayRepository appointmentDayRepository
            , IAppointmentHourRepository appointmentHourRepository
            , IDoctorServcie doctorServcie)
        {
            this.appointmentDayRepository = appointmentDayRepository;
            this.appointmentHourRepository = appointmentHourRepository;
            this.doctorServcie = doctorServcie;
        }

        public  async Task<bool> AddAppointmentAsync(AddAppointmentDto Appointment, string doctorId)
        {
                await doctorServcie.AddDoctorVisitPrice(doctorId,Appointment.Price);

                foreach (KeyValuePair<WeekDays, List<string>> kvp in Appointment.Days)
                {
                    //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    AppointmentDay appointmentDay = new AppointmentDay() 
                    {
                        Day = kvp.Key, DoctorId = doctorId  
                    };

                    var newAppointmentDay = await appointmentDayRepository.AddAsync(appointmentDay);

                    if (newAppointmentDay == null)
                    {
                        return false;
                    }

                foreach (var time in kvp.Value)
                {
                    AppointmentHour appointmentHour = new AppointmentHour()
                    {
                        Time = time,
                        AppointmentDayId = appointmentDay.Id
                    };
                    var newAppointmentHour = await appointmentHourRepository.AddAsync(appointmentHour);

                    if (newAppointmentHour == null)
                    {
                        return false;
                    }
                }

            }

            return true;
        }



        public Task<bool> DeleteAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAppointment(int Id, UpdateAppointmentDto Appointment)
        {
            throw new NotImplementedException();
        }

        public async Task<AppointmentHourDto> GetAppointmentHour(int id)
        {
            AppointmentHour appointmentHour =  await appointmentHourRepository.GetByIdAsync(id);
            AppointmentHourDto AppointmentHour = new AppointmentHourDto()
            {
                Id = appointmentHour.Id,
                AppointmentDayId = appointmentHour.AppointmentDayId,
                Time = appointmentHour.Time,
                Available = appointmentHour.Available,
            };

            return AppointmentHour;
              
        }

        public async Task<AppointmentDayDto> GetAppointmentDay(int id)
        {
            AppointmentDay appointmentDay = await appointmentDayRepository.GetByIdAsync(id);
            AppointmentDayDto AppointmentDay = new AppointmentDayDto()
            {
                Id = appointmentDay.Id,
               DoctorId = appointmentDay.DoctorId,
                Day = appointmentDay.Day
            };
            return AppointmentDay;
        }

        public async Task<bool> UpdateAppointmentStatus(int id, bool Available)
        {
            AppointmentHour appointmentHour =  await appointmentHourRepository.GetByIdAsync(id);
            appointmentHour.Available = Available;
            var result = appointmentHourRepository.Update(appointmentHour);
           
            return result != null;
        }
    }
}
