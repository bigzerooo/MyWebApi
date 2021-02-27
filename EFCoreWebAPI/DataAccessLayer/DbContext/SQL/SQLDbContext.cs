using DataAccessLayer.DbContext.SQL.Configurations;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DbContext.SQL
{
    public class SQLDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarState> CarStates { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CarHire> CarHires { get; set; }
        public DbSet<News> News { get; set; }

        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new CarTypeConfiguration().Configure(builder.Entity<CarType>());
            new CarStateConfiguration().Configure(builder.Entity<CarState>());
            new ClientTypeConfiguration().Configure(builder.Entity<ClientType>());
            new CarConfiguration().Configure(builder.Entity<Car>());
            new ClientConfiguration().Configure(builder.Entity<Client>());
            new CarHireConfiguration().Configure(builder.Entity<CarHire>());
            new NewsConfiguration().Configure(builder.Entity<News>());
        }
    }
}