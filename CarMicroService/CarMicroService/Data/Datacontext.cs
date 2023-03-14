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

        public DbSet<CarModel> Cars { get; set; }

    }
}
