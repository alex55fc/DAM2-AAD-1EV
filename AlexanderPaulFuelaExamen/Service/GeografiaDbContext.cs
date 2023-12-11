using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Service
{
	public class GeografiaDbContext : DbContext
	{
		public GeografiaDbContext(DbContextOptions<GeografiaDbContext> options) : base(options)
		{
		}

		public DbSet<Modelos.Provincia> Provincias { get; set; }
		public IEnumerable<Comunidad> Comunidad { get; internal set; }

		/* esto es para cuando tengamos la tabla Comunidades
		public DbSet<Modelos.Comunidad> Comunidades { get; set; }
		public GeografiaDbContext(){

			}
		*/
	}
}
