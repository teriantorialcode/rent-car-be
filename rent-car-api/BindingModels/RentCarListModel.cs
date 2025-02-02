using System;
namespace rent_car_api.BindingModels
{
    public class RentCarListModel
    {
        public string Brand { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }
    }

}

