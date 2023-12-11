using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Service
{
	public class FutbolDBContext :DbContext
	{ 
		public FutbolDBContext(DbContextOptions<FutbolDBContext> options) : base(options) { }
		public DbSet<Equipo> equipo { get; set; }

		public FutbolDBContext()
		{

		}
	
	}
}
