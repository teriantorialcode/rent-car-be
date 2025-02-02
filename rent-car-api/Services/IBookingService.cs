using System;
using rent_car_api.BindingModels;
using rent_car_api.Models;

namespace rent_car_api.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<string>> GetAvailableSlotsAsync(Guid carModelId, DateTime date);
        Task<BookingResponseModel> BookTestDriveAsync(Booking booking);
    }
}

