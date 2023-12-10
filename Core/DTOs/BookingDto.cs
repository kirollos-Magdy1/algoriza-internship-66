using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string DoctortId { get; set; }

        public string? CouponCode { get; set; }

        public decimal InitialPrice{ get; set; }
        public decimal FinalPrice { get; set; }

        public BookingStatus Status { get; set; }

    }
}
