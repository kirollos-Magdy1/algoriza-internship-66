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
        Task<bool> UpdateCoupon(int Id, UpdateCouponDto coupon);
        Task<bool> DeleteCoupon(int id);

        Task<bool> DeactivateCoupon(int id);

        Task<IEnumerable<CouponDto>> GetAllCouponsAsync();

        Task<CouponDto> GetCouponByCode(string CouponCode);
    }
}
