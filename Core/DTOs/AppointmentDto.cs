using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }


        //public List<WeekDays> Day { get; set; }

        //public List<WeekDaySchedule> Hours { get; set; }


        // public List<WeekDays<string>> Times { get; set; }
        public List<Dictionary<WeekDays, List<string>>> Hours { get; set; }
    }
}
