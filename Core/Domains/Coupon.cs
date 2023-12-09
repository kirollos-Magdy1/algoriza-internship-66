using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? PatientId { get; set; }
        public DiscountType DiscountType { get; set; }

        public int DiscountValue { get; set; }

        // number of completed bookings to be eligible for having discount
        public int EligibleRequests { get; set; }

        public DateTime ExpireDate { get; set; }


        public bool IsActive { get; set; } = true;

        public bool IsUsed { get; set; } = false;

        [ForeignKey("PatientId")]
        public virtual User? Patient { get; set; }
    }
}
