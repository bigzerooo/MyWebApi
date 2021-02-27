using DataAccessLayer.Entities;
using DataAccessLayer.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.DbContext.SQL.Configurations
{
    public class ClientTypeConfiguration : IEntityTypeConfiguration<ClientType>
    {
        public void Configure(EntityTypeBuilder<ClientType> builder)
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
                .HasData(DataInitializer.InitialClientTypes);
        }
    }
}
