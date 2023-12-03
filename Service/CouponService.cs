using Core.Domains;
using Core.DTOs;
using Core.Enums;
using Core.IRepositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CouponService : ICouponService
    {
        private ICouponRepository couponRepository;

        public CouponService(ICouponRepository couponRepository)
        {
            this.couponRepository = couponRepository;
        }

        public async Task<bool> AddCouponAsync(AddCouponDto coupon)
        {
            Coupon NewCoupon = new Coupon()
            {
                Code = coupon.Code,
                DiscountType = coupon.DiscountType,
                DiscountValue = coupon.DiscountValue,
                EligibleRequests = coupon.EligibleRequests,
                ExpireDate = coupon.ExpireDate,
                IsActive = coupon.IsActive,
                IsUsed = coupon.IsUsed
            };

            var Coupon =  await couponRepository.AddAsync(NewCoupon);

           return (Coupon != null) ?true: false;

        }

        public bool DeactivateCoupon(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCoupon(int id)
        {
            throw new NotImplementedException();
        }
        public bool UpdateCoupon(CouponDto coupon)
        {
            return true;
                 //couponRepository.Update(coupon);
        }
        public async Task<IEnumerable<CouponDto>> GetAllCouponsAsync()
        {
           var couponList =  await couponRepository.GetAllAsync();

            if (couponList.Any())
            {
                List<CouponDto> coupons = new List<CouponDto>();

                foreach (var coupon in couponList)
                {
                    CouponDto Coupon = new CouponDto()
                    {
                        Id = coupon.Id,
                        Code = coupon.Code,
                        DiscountType = coupon.DiscountType,
                        DiscountValue = coupon.DiscountValue,
                        EligibleRequests = coupon.EligibleRequests,
                        ExpireDate = coupon.ExpireDate,
                        IsActive = coupon.IsActive,
                        IsUsed = coupon.IsUsed,
                    };

                    coupons.Add(Coupon);
                }

                return coupons;
            }
            else
            {
                return Enumerable.Empty<CouponDto>();
            }

        }

        
    }
}
