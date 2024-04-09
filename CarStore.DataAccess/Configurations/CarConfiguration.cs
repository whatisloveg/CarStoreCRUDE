using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.DataAccess.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CarMake)
                .IsRequired();

            builder.Property(c => c.CarName)
                .IsRequired();

            builder.Property(c => c.Price)
                .IsRequired();
        }
    }
}
