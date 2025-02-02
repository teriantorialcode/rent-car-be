using System;
namespace rent_car_api
{
	public class ApplicationConstant
	{
        public const string ERROR_NOT_FOUND = "Data Not Found";
        public static readonly string[] SLOT_TIME = new string[] { "09:00", "10:00", "11:00", "13:00", "14:00", "15:00" };
        public const string ERROR_ALREADY_BOOKED = "Sorry, the car is already booked";
    }
}

