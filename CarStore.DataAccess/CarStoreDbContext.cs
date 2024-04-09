using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarStore.DataAccess.Entities;

namespace CarStore.DataAccess
{
    public class CarStoreDbContext : DbContext
    {
        public CarStoreDbContext(DbContextOptions<CarStoreDbContext> options)
            : base(options) { }

        public DbSet<CarEntity> Cars { get; set; }   

    }
}
