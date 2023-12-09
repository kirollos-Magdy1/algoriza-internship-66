using Core.Domains;
using Core.DTOs;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class DoctorAppointmentsDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string DateOfBirth { get; set; }

        public string Image { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }
        public int? SpecializationId { get; set; }

        public Specialization Specialization { get; set; }

        // Dictionary<HourId, ["day", "hour"]>
        public Dictionary<int, List<string>> Times { get; set; }

    }
}
