using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICouponService
    {

        Task<bool> AddCouponAsync(AddCouponDto coupon);
        bool UpdateCoupon(CouponDto coupon);
        bool DeleteCoupon(int id);

        bool DeactivateCoupon(int id);

        Task<IEnumerable<CouponDto>> GetAllCouponsAsync();

    }
}
