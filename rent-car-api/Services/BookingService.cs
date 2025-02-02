using System;
using Microsoft.EntityFrameworkCore;
using rent_car_api.BindingModels;
using rent_car_api.Data;
using rent_car_api.Models;

namespace rent_car_api.Services
{

    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetAvailableSlotsAsync(Guid carModelId, DateTime date)
        {
            var bookedSlots = await _context.Bookings
                .Where(b => b.CarModelId == carModelId && b.Date.Date == date.Date)
                .Select(b => b.TimeSlot)
                .ToListAsync();

            var allSlots = ApplicationConstant.SLOT_TIME;
            return allSlots.Except(bookedSlots);
        }

        public async Task<BookingResponseModel> BookTestDriveAsync(Booking booking)
        {
            var isBooked = await _context.Bookings.AnyAsync(b =>
                b.CarModelId == booking.CarModelId &&
                b.Date == booking.Date &&
                b.TimeSlot == booking.TimeSlot);

            if (isBooked)
            {
                return new BookingResponseModel
                {
                    IsSuccessful = false,
                    Message = ApplicationConstant.ERROR_ALREADY_BOOKED
                };
            }

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return new BookingResponseModel
            {
                IsSuccessful = true,
                Message = "Booking successful"
            };
        }

        public async Task<List<RentCarListModel>> GetRentCarListAsync()
        {
            var rentCarList = await (from b in _context.Bookings
                                     join c in _context.Cars on b.CarModelId equals c.Id
                                     select new RentCarListModel
                                     {
                                         Brand = c.Brand, 
                                         CustomerName = b.CustomerName, 
                                         Date = b.Date,
                                         TimeSlot = b.TimeSlot
                                     }).ToListAsync();

            return rentCarList;
        }


    }

}

