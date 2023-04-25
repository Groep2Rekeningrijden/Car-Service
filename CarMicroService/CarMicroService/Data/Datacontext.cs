using System.Collections.Generic;
using CarMicroService.Model;
using Microsoft.EntityFrameworkCore;

namespace CarMicroService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarType>().HasData(new CarType{Id = Guid.NewGuid(), Name = "Benzine", Description = "Benzine auto", PricePerKilometer = 0.11});
            modelBuilder.Entity<Car>().HasData(new Car { Id = Guid.NewGuid(), Name = "volvo V90", Description = "benzine auto volvo v90", CarTypeId = Guid.NewGuid()});
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarType> CarTypes { get; set; }    

        //public DbSet<CarUser> CarUsers { get; set; }
    }
}
