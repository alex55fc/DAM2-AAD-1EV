using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Services
{
    public class FutbolDBContext : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }


        public FutbolDBContext(DbContextOptions<FutbolDBContext> options) : base(options)
        {

        }
    }
}
