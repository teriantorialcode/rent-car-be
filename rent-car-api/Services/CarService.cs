using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using rent_car_api.BindingModels;
using rent_car_api.Data;
using rent_car_api.Models;

namespace rent_car_api.Services
{
	public class CarService : ICarService
	{
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<IEnumerable<Car>> GetAllCarsAsync(int page, int pageSize)
        {
    
            page = page < 1 ? 1 : page; 
            pageSize = pageSize < 1 ? 10 : pageSize; 

            return await _context.Cars
                .Skip((page - 1) * pageSize) 
                .Take(pageSize)            
                .ToListAsync();
        }

        public async Task<List<CarDropDownModel>> GetAllCarsForDropdownAsync()
        {
            var cars = await _context.Cars
                .Select(car => new CarDropDownModel
                {
                    Id = car.Id,
                    Name = $"{car.Brand} - {car.Model}"
                })
                .ToListAsync();

            return cars;
        }

        public async Task<Car> AddCarAsync(CarInsertModel model)
        {
            var carData = _mapper.Map<Car>(model);

            carData.CreatedBy = "ADMIN";
            var result = _context.Cars.Add(carData);

            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateCarAsync(Guid id, Car model)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) throw new KeyNotFoundException(ApplicationConstant.ERROR_NOT_FOUND);

            car.Brand = model.Brand;
            car.Model = model.Model;
            car.Year = model.Year;
            car.ImageUrl = model.ImageUrl;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) throw new KeyNotFoundException(ApplicationConstant.ERROR_NOT_FOUND);

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> AddCarModelAsync(Car model)
        {
            _context.Cars.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }

}

