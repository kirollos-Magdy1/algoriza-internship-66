using Core.Domains;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AddBookingDto
    {
        public int TimeId { get; set; }
        public string DiscountCode { get; set; }

    }
}
