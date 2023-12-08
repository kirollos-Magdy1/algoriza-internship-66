using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppointmentDayRepository: BaseRepository<AppointmentDay>, IAppointmentDayRepository
    {
        public AppointmentDayRepository(ApplicationDbContext context): base(context)
        {
            
        }
    }
}
