using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DBContext
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options) :base(options)
        {            
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CarType

            modelBuilder.Entity<CarType>()
                .HasKey(p => p.Type);

            modelBuilder.Entity<CarType>()
                .Property(p => p.Type)
                .HasMaxLength(45);

            #endregion
            #region CarState

            modelBuilder.Entity<CarState>()
                .HasKey(p => p.State);

            modelBuilder.Entity<CarState>()
                .Property(p => p.State)
                .HasMaxLength(45);

            #endregion
            #region ClientType

            modelBuilder.Entity<ClientType>()
                .HasKey(p => p.Type);

            modelBuilder.Entity<ClientType>()
                .Property(p => p.Type)
                .HasMaxLength(45);

            #endregion
            #region Car

            modelBuilder.Entity<Car>()
                .HasOne<CarType>(c => c.CarType)
                .WithMany(t => t.Cars)
                .HasForeignKey(c => c.Type);

            modelBuilder.Entity<Car>()
                .Property(p => p.Brand)
                .IsRequired();

            modelBuilder.Entity<Car>()
                .Property(p => p.Brand)
                .HasMaxLength(45);

            modelBuilder.Entity<Car>()
                .Property(p => p.Price)
                .IsRequired();

            modelBuilder.Entity<Car>()
                .Property(p => p.PricePerHour)
                .IsRequired();

            modelBuilder.Entity<Car>()
                .Property(p => p.Type)
                .HasMaxLength(45);

            #endregion
            #region Client

            modelBuilder.Entity<Client>()
                .HasOne<ClientType>(c => c.ClientType)
                .WithMany(t => t.Clients)
                .HasForeignKey(c => c.TypeOfClient);

            modelBuilder.Entity<Client>()
                .Property(p => p.LastName)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(p => p.LastName)
                .HasMaxLength(45);

            modelBuilder.Entity<Client>()
                .Property(p => p.FirstName)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(p => p.FirstName)
                .HasMaxLength(45);

            modelBuilder.Entity<Client>()
                .Property(p => p.SecondName)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(p => p.SecondName)
                .HasMaxLength(45);

            modelBuilder.Entity<Client>()
                .Property(p => p.Adress)
                .HasMaxLength(45);

            modelBuilder.Entity<Client>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(45);

            modelBuilder.Entity<Client>()
                .Property(p => p.TypeOfClient)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(p => p.TypeOfClient)
                .HasMaxLength(45);
            #endregion
            #region CarHire
            #region ForeignKeys

            modelBuilder.Entity<CarHire>()
                .HasOne<Client>(h => h.Client)
                .WithMany(c => c.CarHires)
                .HasForeignKey(h => h.ClientId);

            modelBuilder.Entity<CarHire>()
                .HasOne<Car>(h => h.Car)
                .WithMany(c => c.CarHires)
                .HasForeignKey(h => h.CarId);

            modelBuilder.Entity<CarHire>()
                .HasOne<CarState>(h => h.State)
                .WithMany(s => s.CarHires)
                .HasForeignKey(h => h.CarState);

            #endregion
            modelBuilder.Entity<CarHire>()
                .Property(p => p.CarId)
                .IsRequired();

            modelBuilder.Entity<CarHire>()
                .Property(p => p.ClientId)
                .IsRequired();

            modelBuilder.Entity<CarHire>()
                .Property(p => p.BeginDate)
                .IsRequired();

            modelBuilder.Entity<CarHire>()
                .Property(p => p.EndDate)
                .IsRequired();

            modelBuilder.Entity<CarHire>()
                .Property(p => p.CarState)
                .IsRequired();

            modelBuilder.Entity<CarHire>()
                .Property(p => p.CarState)
                .HasMaxLength(45);

            modelBuilder.Entity<CarHire>()
                .Property(p => p.Price)
                .IsRequired();


            #endregion

        }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarState> CarStates { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CarHire> CarHires { get; set; }
    }
}
