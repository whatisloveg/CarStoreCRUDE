using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.DataAccess.Entities
{
    public class CarEntity
    {

        public Guid Id { get; set; }
        public string CarMake { get; set; } = string.Empty;
        public string CarName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
