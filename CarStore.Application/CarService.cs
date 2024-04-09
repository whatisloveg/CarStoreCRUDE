using CarStore.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models;

namespace CarStore.Application
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _carRepository.Get();
        }

        public async Task<Guid> CreateCar(Car car)
        {
            return await _carRepository.Create(car);
        }

        public async Task<Guid> UpdateCar(Guid id, string carMake, string carName, decimal price)
        {
            return await _carRepository.Update(id, carMake, carName, price);
        }

        public async Task<Guid> DeleteCar(Guid id)
        {
            return await _carRepository.Delete(id);
        }
    }
}
