using Core.Domains;
using Core.Repositories;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppointmentHourRepository : BaseRepository<AppointmentHour>, IAppointmentHourRepository
    {
        public AppointmentHourRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

