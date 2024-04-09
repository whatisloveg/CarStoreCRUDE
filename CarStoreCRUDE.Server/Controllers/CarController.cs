using CarStore.Application;
using CarStore.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarStoreCRUDE.Server.Contracts;
using System.Diagnostics.Eventing.Reader;
using CarStore.Core.Models;

namespace CarStoreCRUDE.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarResponse>>> GetCars()
        {
            var cars = await _carService.GetAllCars();

            var response = cars.Select(c => new CarResponse(c.Id, c.CarMake, c.CarName, c.Price));

            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCar([FromBody] CarRequest request)
        {
            var (car, error) = Car.Create(Guid.NewGuid(), request.CarMake, request.CarName, request.Price);

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookId = await _carService.CreateCar(car);

            return Ok(bookId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCar(Guid id, [FromBody] CarRequest request)
        {
            var bookId = await _carService.UpdateCar(id, request.CarMake, request.CarName, request.Price);
            return Ok(bookId);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteCar(Guid id)
        {
            var response = await _carService.DeleteCar(id);
            return Ok(response);
        }
    }
}
