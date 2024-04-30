using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.Context
{
    public class TravelaContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ultrabook;Initial Catalog=DbTravela;Integrated Security=True");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}
