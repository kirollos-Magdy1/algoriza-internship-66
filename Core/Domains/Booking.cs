using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Booking
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }

        public int CouponId { get; set; }



        [ForeignKey("PatientId")]
        public User Patient { get; set; }

        [ForeignKey("DoctorId")]
        public User Doctor { get; set; }

        [ForeignKey("CouponId")]
        public Coupon Coupon { get; set; }

    }
}
