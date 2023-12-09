using Core.DTOs;
using Core.Enums;
using Core.IRepositories;
using Core.Services;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepository bookingRepository;
        private readonly ICouponService couponService;
        private readonly IAppointmentService appointmentService;

        public BookingService(IBookingRepository bookingRepository, ICouponService couponService)
        {
            this.bookingRepository = bookingRepository;
            this.couponService = couponService;
            this.appointmentService = appointmentService;
        }

        public async Task<BookingDto> CreateBookingAsync(string PatientId, AddBookingDto addBookingDto)
        {

            CouponDto coupon =  await couponService.GetCouponByCode(addBookingDto.DiscountCode);
            AppointmentHourDto appointmentHour = await appointmentService.GetAppointmentHour(addBookingDto.TimeId);


            return new BookingDto();

            Console.WriteLine("PatientId");
            Console.WriteLine(PatientId);

            

        }

        public Task<IEnumerable<BookingDto>> GetAllMyBookingsAsync(int? pageSize, int? skip, int? take, string? search)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBookingStatus(int Id, BookingStatus Status)
        {
            throw new NotImplementedException();
        }
    }
}






//public async Task<bool> AddCouponAsync(AddCouponDto coupon)
//{
//    Console.Out.WriteLine(coupon.DiscountType.GetType());
//    Console.Out.WriteLine((int)coupon.DiscountType);

//    if (((int)coupon.DiscountType) > 1) return false;

//    Coupon NewCoupon = new Coupon()
//    {
//        Code = coupon.Code,
//        DiscountType = coupon.DiscountType,
//        DiscountValue = coupon.DiscountValue,
//        EligibleRequests = coupon.EligibleRequests,
//        ExpireDate = coupon.ExpireDate,
//        IsActive = coupon.IsActive,
//        IsUsed = coupon.IsUsed
//    };

//    var Coupon = await couponRepository.AddAsync(NewCoupon);

//    return (Coupon != null) ? true : false;

//}


//public async Task<bool> UpdateCoupon(int Id, UpdateCouponDto coupon)
//{
//    var ExistingCoupon = await couponRepository.GetByIdAsync(Id);
//    if (ExistingCoupon == null || (int)coupon.DiscountType > 1) { return false; }

//    ExistingCoupon.Code = coupon.Code;
//    ExistingCoupon.DiscountType = coupon.DiscountType;
//    ExistingCoupon.DiscountValue = coupon.DiscountValue;
//    ExistingCoupon.EligibleRequests = coupon.EligibleRequests;
//    ExistingCoupon.ExpireDate = coupon.ExpireDate;

//    var UpdatedCoupon = couponRepository.Update(ExistingCoupon);
//    return true;

//}
//public async Task<IEnumerable<CouponDto>> GetAllCouponsAsync()
//{
//    var couponList = await couponRepository.GetAllAsync();

//    if (couponList.Any())
//    {
//        List<CouponDto> coupons = new List<CouponDto>();

//        foreach (var coupon in couponList)
//        {
//            CouponDto Coupon = new CouponDto()
//            {
//                Id = coupon.Id,
//                Code = coupon.Code,
//                DiscountType = coupon.DiscountType,
//                DiscountValue = coupon.DiscountValue,
//                EligibleRequests = coupon.EligibleRequests,
//                ExpireDate = coupon.ExpireDate,
//                IsActive = coupon.IsActive,
//                IsUsed = coupon.IsUsed,
//            };

//            coupons.Add(Coupon);
//        }

//        return coupons;
//    }
//    else
//    {
//        return Enumerable.Empty<CouponDto>();
//    }

//}