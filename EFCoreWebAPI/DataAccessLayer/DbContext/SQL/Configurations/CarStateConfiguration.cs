using DataAccessLayer.Entities;
using DataAccessLayer.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.DbContext.SQL.Configurations
{
    public class CarStateConfiguration : IEntityTypeConfiguration<CarState>
    {
        public void Configure(EntityTypeBuilder<CarState> builder)
        {
            builder
                .HasKey(cs => cs.Id);

            builder
                .Property(cs => cs.State)
                .HasMaxLength(45);

            builder
                .HasIndex(cs => cs.State)
                .IsUnique();

            builder
                .HasData(DataInitializer.InitialCarStates);
        }
    }
}
