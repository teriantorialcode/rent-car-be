using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rent_car_api.Models;
using rent_car_api.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rent_car_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> BookTestDrive([FromBody] Booking booking)
        {
            try
            {
                var response = await _bookingService.BookTestDriveAsync(booking);

                if (!response.IsSuccessful)
                {
                    return BadRequest(new { message = response.Message });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred" });
            }
        }


        [HttpGet("{carId}/{date}")]
        public async Task<IActionResult> GetAvailableSlots(Guid carId, DateTime date)
        {
            var availableSlots = await _bookingService.GetAvailableSlotsAsync(carId, date);
            return Ok(availableSlots);
        }
    }

}

