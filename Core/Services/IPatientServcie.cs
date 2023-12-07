using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPatientServcie
    {

        Task<IEnumerable<PatientDto>> GetAllPatientsAsync(int? pageSize, int? skip, int? take);
        Task<PatientDto> GetPatientAsync(string Id);
    }
}
