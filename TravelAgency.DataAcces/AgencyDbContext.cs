using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Entities.Entities;

namespace TravelAgency.DataAcces
{
    public class AgencyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\LocalDB; Database=AgencyDB;");
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
