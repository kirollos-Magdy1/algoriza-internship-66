using Core.Domains;
using Core.IRepositories;
using Core.Repositories;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SpecializationRepositroy: BaseRepository<Specialization>, ISpecializationRepositroy
    {
        SpecializationRepositroy(ApplicationDbContext context): base(context) { }
    }
}
