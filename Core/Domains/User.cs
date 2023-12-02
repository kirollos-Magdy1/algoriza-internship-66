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
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int SpecializationId { get; set; }

        public Gender Gender{ get; set; }
        public int CompletedBookings { get; set; }

        public int CouponsUsed { get; set; }
    }
}
