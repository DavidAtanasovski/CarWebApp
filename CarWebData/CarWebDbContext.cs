using CarWebCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWebData
{
    public class CarWebDbContext : DbContext
    {
        public CarWebDbContext(DbContextOptions<CarWebDbContext> options) : base (options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
