using System;
namespace rent_car_api.Models
{
    public class Car : BaseModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
    }
}

