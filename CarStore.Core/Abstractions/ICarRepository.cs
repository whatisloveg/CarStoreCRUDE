using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models;

namespace CarStore.Core.Abstractions
{
    public interface ICarRepository
    {
        Task<List<Car>> Get();
        Task<Guid> Create(Car car);
        Task<Guid> Update(Guid id, string carMake, string carName, decimal price);
        Task<Guid> Delete(Guid carId);

    }
}
