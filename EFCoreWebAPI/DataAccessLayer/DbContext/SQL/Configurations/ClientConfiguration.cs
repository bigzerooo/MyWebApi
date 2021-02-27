using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.DbContext.SQL.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasOne(c => c.ClientType)
                .WithMany(t => t.Clients)
                .HasForeignKey(c => c.ClientTypeId);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(45);

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(45);

            builder
                .Property(p => p.SecondName)
                .HasMaxLength(45);

            builder
                .Property(p => p.Adress)
                .HasMaxLength(45);

            builder
                .Property(p => p.PhoneNumber)
                .HasMaxLength(45);

            builder
                .Property(p => p.ClientTypeId)
                .IsRequired();

            builder
                .HasOne(u => u.User)
                .WithOne(c => c.Client)
                .HasForeignKey<User>(c => c.ClientId);

            builder
                .HasData(DataInitializer.InitialClients);
        }
    }
}
