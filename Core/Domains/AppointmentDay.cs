using Core.Enums;
using System;
using System.Collections.Generic;
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

        public WeekDays Day { get; set; }


        [ForeignKey("DoctorId")]
        public User Doctor { get; set; }

        List<AppointmentHour> AppointmentHours { get; set; }
    }
}
