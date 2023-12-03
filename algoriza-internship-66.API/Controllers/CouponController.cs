using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace algoriza_internship_66.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CouponController : Controller
    {
        private ICouponService couponService;

        public CouponController(ICouponService couponService)
        {
            this.couponService = couponService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon()

        [HttpGet]
        public async Task<IActionResult> GetAllCoupons()
        {
            try
            {
                var coupons = await couponService.GetAllCouponsAsync();
                return Ok(coupons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon([FromBody] AddCouponDto addCouponDto)
        {
            try
            {
                var NewCoupon = await couponService.AddCouponAsync(addCouponDto);

                if(NewCoupon != null)
                {
                    return Ok(true);
                }
                else { return BadRequest(false); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
