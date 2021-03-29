using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantoshApp.Models
{
    public class PatilDbContext :DbContext
    {
        public PatilDbContext(DbContextOptions<PatilDbContext> options) :base(options)
        {

        }

        public DbSet<HotelModel> HotelModels { get; set; }
        public DbSet<BusModel> BusModels { get; set; }
    }
}
