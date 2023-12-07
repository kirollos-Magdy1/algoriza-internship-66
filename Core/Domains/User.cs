using Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class User: IdentityUser
    {

        public Gender Gender{ get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string DateOfBirth { get; set; }

        public string? Image { get; set; }


        public int? SpecializationId { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        public int CompletedBookings { get; set; }

        public int CouponsUsed { get; set; }
    }
}
