using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace rent_car_api.Models
{
    public class Booking : BaseModel
    {
        public Guid CarModelId { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }
}

