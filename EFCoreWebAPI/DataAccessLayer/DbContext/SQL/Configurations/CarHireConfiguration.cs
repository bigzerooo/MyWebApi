using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.DbContext.SQL.Configurations
{
    public class CarHireConfiguration : IEntityTypeConfiguration<CarHire>
    {
        public void Configure(EntityTypeBuilder<CarHire> builder)
        {
            builder
                .HasOne(h => h.Client)
                .WithMany(c => c.CarHires)
                .HasForeignKey(h => h.ClientId);

            builder
                .HasOne(h => h.Car)
                .WithMany(c => c.CarHires)
                .HasForeignKey(h => h.CarId);

            builder
                .HasOne(h => h.State)
                .WithMany(s => s.CarHires)
                .HasForeignKey(h => h.CarStateId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .Property(p => p.CarId)
                .IsRequired();

            builder
                .Property(p => p.ClientId)
                .IsRequired();

            builder
                .Property(p => p.BeginDate)
                .IsRequired();

            builder
                .Property(p => p.ExpectedEndDate)
                .IsRequired();

            builder
                .Property(p => p.ExpectedPrice)
                .IsRequired();
        }
    }
}
