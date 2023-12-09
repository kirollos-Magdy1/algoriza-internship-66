using Core.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AppointmentHourDto
    {
        public int Id { get; set; }

        public int AppointmentDayId { get; set; }

        public string Time { get; set; }

        public bool Available { get; set; }

    }
}
