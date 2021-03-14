using DataAccessLayer.Entities;
using DataAccessLayer.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.DbContext.SQL.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(c => c.CarType)
                .WithMany(t => t.Cars)
                .HasForeignKey(c => c.CarTypeId);

            builder
                .Property(p => p.Brand)
                .IsRequired()
                .HasMaxLength(45);

            builder
                .Property(p => p.Price)
                .IsRequired();

            builder
                .Property(p => p.PricePerHour)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(1000);

            builder
                .HasData(DataInitializer.InitialCars);
        }
    }
}
