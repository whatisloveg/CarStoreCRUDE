using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Abstractions;
using CarStore.Core.Models;
using CarStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarStore.DataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarStoreDbContext _context;
        public CarRepository(CarStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> Get()
        {
            var carEntites = await _context.Cars
                .AsNoTracking()
                .ToListAsync();

            var cars = carEntites
                .Select(c => Car.Create(c.Id, c.CarMake, c.CarName, c.Price).Сar)
                .ToList();

            return cars;
        }

        public async Task<Guid> Create(Car car)
        {
            var carEntity = new CarEntity
            {
                Id = car.Id,
                CarMake = car.CarMake,
                CarName = car.CarName,
                Price = car.Price
            };

            await _context.Cars.AddAsync(carEntity);
            await _context.SaveChangesAsync();
            return carEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string carMake, string carName, decimal price)
        {
            await _context.Cars
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.CarMake, c => carMake)
                .SetProperty(c => c.CarName, c => carName)
                .SetProperty(c => c.Price, c => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Cars
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
