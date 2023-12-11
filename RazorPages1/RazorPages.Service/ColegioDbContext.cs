using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RazorPages.Modelos;

namespace RazorPages.Service
{
	public class ColegioDBContext : DbContext
	{   
        //constructor
        public ColegioDBContext(DbContextOptions<ColegioDBContext> options) : base(options){


        }
        //tabla con DbSet
        public DbSet<Alumno>Alumnos { get; set; }

    }
}
