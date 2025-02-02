using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rent_car_api.BindingModels;
using rent_car_api.Models;
using rent_car_api.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rent_car_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CarController : ControllerBase
    {
        private readonly ICarService _carModelService;

        public CarController(ICarService carModelService)
        {
            _carModelService = carModelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarModels(int page = 1, int pageSize = 10)
        {
            var carModels = await _carModelService.GetAllCarsAsync(page, pageSize);
            return Ok(carModels);
        }

        [HttpGet("getallcars")]
        public async Task<IActionResult> GetAllCars()
        {
            var carModels = await _carModelService.GetAllCarsForDropdownAsync();
            return Ok(carModels);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CarInsertModel model)
        {
            var createdModel = await _carModelService.AddCarAsync(model);
            return CreatedAtAction(nameof(GetAllCarModels), new { id = createdModel.Id }, createdModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, [FromBody] Car model)
        {
            await _carModelService.UpdateCarAsync(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            await _carModelService.DeleteCarAsync(id);
            return NoContent();
        }
    }

}

