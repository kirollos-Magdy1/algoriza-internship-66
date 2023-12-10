using Core.Domains;
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
        private readonly IDoctorServcie doctorServcie;

        public BookingService(IBookingRepository bookingRepository, ICouponService couponService,
            IAppointmentService appointmentService, IDoctorServcie doctorServcie)
        {
            this.bookingRepository = bookingRepository;
            this.couponService = couponService;
            this.appointmentService = appointmentService;
            this.doctorServcie = doctorServcie;
        }

        public async Task<bool> AddBookingAsync(string PatientId, AddBookingDto addBookingDto)
        {

            CouponDto coupon =  await couponService.GetCouponByCode(addBookingDto.DiscountCode);
            AppointmentHourDto appointmentHour = await appointmentService.GetAppointmentHour(addBookingDto.TimeId);
            AppointmentDayDto appointmentDay = await appointmentService.GetAppointmentDay(appointmentHour.AppointmentDayId);
            DoctorDto doctor = await doctorServcie.GetDoctorAsync(appointmentDay.DoctorId);
            string doctorId = appointmentDay.DoctorId;

            Booking booking = new Booking()
            {
                PatientId = PatientId,
                DoctorId = doctorId,
                initialPrice = (decimal)doctor.Price,
                finalPrice = 0,
                Status = BookingStatus.Pending
            };

            var res = await appointmentService.UpdateAppointmentStatus(addBookingDto.TimeId, false);
            //bookingRepository.AddAsync()
            // NewAppointmentHour

            //appointmentService.UpdateAppointment(appointmentHour.Id, NewAppointmentHour)

            var result = await bookingRepository.AddAsync(booking);

            return (result != null);


        }

        public Task<IEnumerable<BookingDto>> GetAllMyBookingsAsync(string userId, int? pageSize, int? skip, int? take, string? search)
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