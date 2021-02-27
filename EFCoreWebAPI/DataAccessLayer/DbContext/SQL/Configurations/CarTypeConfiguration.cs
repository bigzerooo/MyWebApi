using DataAccessLayer.Entities;
using DataAccessLayer.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.DbContext.SQL.Configurations
{
    public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
    {
        public void Configure(EntityTypeBuilder<CarType> builder)
        {
            builder
                .HasKey(ct => ct.Id);

            builder
                .Property(ct => ct.Type)
                .HasMaxLength(45);

            builder
                .HasIndex(ct => ct.Type)
                .IsUnique();

            builder
                .HasData(DataInitializer.InitialCarTypes);
        }
    }
}
