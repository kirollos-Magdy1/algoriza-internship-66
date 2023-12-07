using Core.Domains;
using Core.DTOs;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ISpecializationService
    {
        Task<IEnumerable<Specialization>> GetAllSpecializationsAsync();
    }
}
