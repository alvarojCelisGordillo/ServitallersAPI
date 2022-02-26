using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServitallersAPI.Models;

namespace ServitallersAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
