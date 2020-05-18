using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DBContext
{
    public class MyDBContext : IdentityDbContext<MyUser, MyRole, int>
    {
        //public MyDBContext(DbContextOptions options) : base(options)
        //{

        //}
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            Database.EnsureCreated();   //?
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region CarType

            modelBuilder.Entity<CarType>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<CarType>()                
                .Property(p => p.Type)                
                .HasMaxLength(45);

            modelBuilder.Entity<CarType>()
                .HasIndex(x=>x.Type)
                .IsUnique();

            #endregion
            #region CarState

            modelBuilder.Entity<CarState>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<CarState>()
                .Property(p => p.State)
                .HasMaxLength(45);

            modelBuilder.Entity<CarState>()
                .HasIndex(x => x.State)
                .IsUnique();            

            #endregion
            #region ClientType

            modelBuilder.Entity<ClientType>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ClientType>()
                .Property(p => p.Type)
                .HasMaxLength(45);

            modelBuilder.Entity<ClientType>()
                .HasIndex(x => x.Type)
                .IsUnique();

            #endregion
            #region Car

            modelBuilder.Entity<Car>()
                .HasOne<CarType>(c => c.CarType)
                .WithMany(t => t.Cars)
                .HasForeignKey(c => c.CarTypeId);

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
                .Property(p => p.Description)
                .HasMaxLength(1000);
            //modelBuilder.Entity<Car>()
            //    .Property(p => p.Type)
            //    .HasMaxLength(45);

            #endregion
            #region Client

            modelBuilder.Entity<Client>()
                .HasOne<ClientType>(c => c.ClientType)
                .WithMany(t => t.Clients)
                .HasForeignKey(c => c.ClientTypeId);

            //modelBuilder.Entity<Client>()
            //    .Property(p => p.LastName)
            //    .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(p => p.LastName)
                .HasMaxLength(45);

            //modelBuilder.Entity<Client>()
            //    .Property(p => p.FirstName)
            //    .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(p => p.FirstName)
                .HasMaxLength(45);

            //modelBuilder.Entity<Client>()
            //    .Property(p => p.SecondName)
            //    .IsRequired();

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
                .Property(p => p.ClientTypeId)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .HasOne<MyUser>(u => u.User)
                .WithOne(c => c.Client)
                .HasForeignKey<MyUser>(c => c.ClientId);
                
            //modelBuilder.Entity<Client>()
            //    .Property(p => p.TypeOfClient)
            //    .HasMaxLength(45);
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
                .HasForeignKey(h => h.CarStateId);

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
                .Property(p => p.CarStateId)
                .IsRequired();

            //modelBuilder.Entity<CarHire>()
            //    .Property(p => p.CarState)
            //    .HasMaxLength(45);

            modelBuilder.Entity<CarHire>()
                .Property(p => p.Price)
                .IsRequired();


            #endregion
            #region Seeding

            modelBuilder.Entity<CarType>().HasData(new CarType[] {
                new CarType{Id=1,Type="Легковой" },
                new CarType{Id=2,Type="Грузовой" },
                new CarType{Id=3,Type="Автобус" },
                new CarType{Id=4,Type="Спортивный" },
                new CarType{Id=5,Type="Внедорожник" },
                new CarType{Id=6,Type="Тягач" },
                new CarType{Id=7,Type="Мотоцикл" }                
            });
            modelBuilder.Entity<ClientType>().HasData(new ClientType[]
            {
                new ClientType{Id=1, Type="Обычный" },
                new ClientType{Id=2, Type="Постоянный"}
            });
            modelBuilder.Entity<CarState>().HasData(new CarState[]
            {
                new CarState{Id=1, State="Хорошое" },
                new CarState{Id=2, State="Плохое" }
            });
            modelBuilder.Entity<Client>().HasData(new Client[]
            {
                new Client{Id=1, FirstName="Admin", LastName="Admin", SecondName="Admin", ClientTypeId=1}
            });


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
