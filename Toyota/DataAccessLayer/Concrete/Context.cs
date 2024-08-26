using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KODJSDM;database=Toyota;integrated security=true;TrustServerCertificate=True");
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
