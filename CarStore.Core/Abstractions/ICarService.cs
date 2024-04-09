using CarStore.Core.Models;

namespace CarStore.Application
{
    public interface ICarService
    {
        Task<Guid> CreateCar(Car car);
        Task<Guid> DeleteCar(Guid id);
        Task<List<Car>> GetAllCars();
        Task<Guid> UpdateCar(Guid id, string carMake, string carName, decimal price);
    }
}