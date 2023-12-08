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
            Console.Out.WriteLine(coupon.DiscountType.GetType());
            Console.Out.WriteLine((int)coupon.DiscountType);

            if (((int)coupon.DiscountType) > 1) return false;

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

       
        public async Task<bool> UpdateCoupon(int Id, UpdateCouponDto coupon)
        {
            var ExistingCoupon =  await couponRepository.GetByIdAsync(Id);
            if (ExistingCoupon == null || (int)coupon.DiscountType > 1) { return false; }   

            ExistingCoupon.Code = coupon.Code;
            ExistingCoupon.DiscountType = coupon.DiscountType;
            ExistingCoupon.DiscountValue = coupon.DiscountValue;
            ExistingCoupon.EligibleRequests = coupon.EligibleRequests;
            ExistingCoupon.ExpireDate = coupon.ExpireDate;

            var UpdatedCoupon = couponRepository.Update(ExistingCoupon);
            return true;
                
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

       

        public async Task<bool> DeactivateCoupon(int Id)
        {
            var ExistingCoupon = await couponRepository.GetByIdAsync(Id);
            if (ExistingCoupon == null || ExistingCoupon.IsActive == false) { return false; }

            ExistingCoupon.IsActive = false;
            
            return(couponRepository.Update(ExistingCoupon) != null);
        }

        public async Task<bool> DeleteCoupon(int Id)
        {
            var Coupon = await couponRepository.GetByIdAsync(Id);

            if (Coupon == null) { return false; }

            return (couponRepository.Delete(Coupon) != null);

        }
    }
}
