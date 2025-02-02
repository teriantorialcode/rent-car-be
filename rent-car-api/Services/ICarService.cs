using System;
using rent_car_api.BindingModels;
using rent_car_api.Models;

namespace rent_car_api.Services
{
	public interface ICarService
	{
        Task<IEnumerable<Car>> GetAllCarsAsync(int page, int pageSize);
        Task<List<CarDropDownModel>> GetAllCarsForDropdownAsync();
        Task<Car> AddCarAsync(CarInsertModel model);
        Task UpdateCarAsync(Guid id, Car model);
        Task DeleteCarAsync(Guid id);
    }
}

