using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDoctorServcie
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync(int? pageSize, int? skip, int? take);
        Task<IEnumerable<DoctorAppointmentsDto>> GetAllDoctorsAppointmentAsync(int? pageSize, int? skip, int? take, string? search);

        Task<DoctorDto> GetDoctorAsync(string Id);

        Task<bool> UpdateDoctorAsync(string Id, UpdateDoctorDto doctor);
        Task<bool> DeleteDoctorAsync(string id);

        Task<bool> AddDoctorVisitPrice(string doctorId, decimal price);


    }
}
