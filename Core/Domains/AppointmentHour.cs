using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class AppointmentHour
    {
        public int Id { get; set; }

        public int AppointmentDayId { get; set; }



        public bool Available { get; set; } = true;
            

        [ForeignKey("AppointmentDayId")]
        public AppointmentDay AppointmentDay  { get; set; }


    }
}
