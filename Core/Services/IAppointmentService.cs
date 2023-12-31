﻿using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAppointmentService
    {
        Task<bool> AddAppointmentAsync(AddAppointmentDto Appointment, string doctorId);
        Task<bool> UpdateAppointment(int Id, UpdateAppointmentDto Appointment);
        Task<bool> DeleteAppointment(int id);

        Task<AppointmentHourDto> GetAppointmentHour(int id);
        Task<AppointmentDayDto> GetAppointmentDay(int id);


        Task<bool> UpdateAppointmentStatus(int id, bool Available);

    }
}
