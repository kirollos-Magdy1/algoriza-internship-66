using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{

    public class AddAppointmentDto
    {
        public decimal Price { get; set; }
        public Dictionary<WeekDays, List<string>> Days { get; set; }
    }




    //public class WeekDaySchedule
    //{
    //    public int Id { get; set; }

    //    public decimal Price { get; set; }

    //    public WeekDays Day { get; set; }
    //    public List<string> Times { get; set; }
    //}
}




//public List<WeekDays> WeekDays { get; set; }

