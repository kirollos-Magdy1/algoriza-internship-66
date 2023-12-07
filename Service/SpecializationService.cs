using Core.Domains;
using Core.DTOs;
using Core.IRepositories;
using Core.Repositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepositroy specializationRepositroy;
        public SpecializationService(ISpecializationRepositroy specializationRepositroy)
        {
            this.specializationRepositroy = specializationRepositroy;
        }


        public async Task<IEnumerable<Specialization>> GetAllSpecializationsAsync()
        {
            var specializationList = await specializationRepositroy.GetAllAsync();

            if (specializationList.Any())
            {
                List<Specialization> specializations = new List<Specialization>();

                foreach (var specialization in specializationList)
                {
                    Specialization Specialization = new Specialization()
                    {
                        Id = specialization.Id,
                        Name = specialization.Name
                    };

                    specializations.Add(Specialization);
                }

                return specializations;
            }
            else
            {
                return Enumerable.Empty<Specialization>();
            }

        }
    }
}
