﻿using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class UpdateAppointmentDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public List<Dictionary<WeekDays, List<string>>> Hours { get; set; }
    }
}
