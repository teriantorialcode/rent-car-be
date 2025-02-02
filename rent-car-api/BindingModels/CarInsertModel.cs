using System;
namespace rent_car_api.BindingModels
{
	public class CarInsertModel
	{
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
    }
}

