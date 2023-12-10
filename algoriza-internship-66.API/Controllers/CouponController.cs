using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace algoriza_internship_66.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class CouponController : Controller
    {
        private ICouponService couponService;

        public CouponController(ICouponService couponService)
        {
            this.couponService = couponService;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCoupon(int Id)
        {
            try
            {
                var isDeleted = await couponService.DeleteCoupon(Id);
                return (isDeleted) ? Ok(true) : BadRequest("Could not deleted");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> DeactivateCoupon(int Id)
        {
            try
            {
                var isDeactivated = await couponService.DeactivateCoupon(Id);
                return (isDeactivated) ? Ok(true) : BadRequest("Could not deactivate");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCoupon(int Id, [FromBody] UpdateCouponDto updateCouponDto)
        {
            try
            {
                var isUpdated = await couponService.UpdateCoupon(Id, updateCouponDto);
                return (isUpdated) ? Ok(true) : BadRequest("Could not update");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

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
