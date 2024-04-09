using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models
{
    public class Car
    {
        private Car(Guid id, string carMake, string carName, decimal price)
        {
            Id = id;
            CarMake = carMake;
            CarName = carName;
            Price = price;
        }

        public Guid Id { get; }
        public string CarMake { get; } = string.Empty;
        public string CarName { get; } = string.Empty;
        public decimal Price { get; }

        public static (Car Сar, string Error) Create(Guid id, string carMake, string carName, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(carMake))
            {
                error = "Car Make can't be null or empty";
            }

            var car = new Car(id, carMake, carName, price);
            return (car, error);
        }
    }
}
