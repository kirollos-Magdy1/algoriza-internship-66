﻿using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public DiscountType DiscountType { get; set; }

        // number of completed bookings to be eligible for having discount
        public int EligibleRequests { get; set; }

        public DateTime ExpireDate { get; set; }

        public int DiscountValue { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsUsed { get; set; } = false;
    }
}