﻿using Core.Domains;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class DoctorDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string DateOfBirth { get; set; }

        public string Image { get; set; }

        public string Gender{ get; set; }

        public string Email { get; set; }

        public decimal? Price { get; set; }

        public int? SpecializationId { get; set; }

        public Specialization? Specialization {  get; set; }

    }
}
