using Core.DTOs;
using Core.Enums;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace algoriza_internship_66.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BookingController: Controller
    {

        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
     

        [HttpPost()]
        public async Task<IActionResult> CreateBooking([FromBody] AddBookingDto addBookingDto)
        {
            var patientId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                var booking = await bookingService.AddBookingAsync(patientId.ToString(), addBookingDto);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBookings(int? pageSize, int? skip, int? take, string? search)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                var bookings = await bookingService.GetAllMyBookingsAsync(userId.ToString(), pageSize, skip, take,search);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Id")]
        public async Task<IActionResult> ConfirmBooking(int Id)
        {
            try
            {
                var isUpdated = await bookingService.UpdateBookingStatus(Id, BookingStatus.Completed);

                return (isUpdated) ? Ok(true) : BadRequest("Could not update");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> CancelBooking(int Id)
        {
            try
            {
                var isUpdated = await bookingService.UpdateBookingStatus(Id, BookingStatus.Canceled);

                return (isUpdated) ? Ok(true) : BadRequest("Could not update");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
