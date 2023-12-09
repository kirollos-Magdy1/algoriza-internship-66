using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class AppointmentDay
    {

        public int Id { get; set; }
        public string DoctorId { get; set; }

        //[Key, Column(Order = 1)]
        public WeekDays Day { get; set; }

        [ForeignKey("DoctorId")]
        public virtual User Doctor { get; set; }

        public virtual  List<AppointmentHour> AppointmentHours { get; set; }
    }
}
