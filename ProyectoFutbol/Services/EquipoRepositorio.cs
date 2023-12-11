using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

//using modelos
namespace Services
{
    public class EquipoRepositorio : IEquipoRepositorio
    {
        private readonly FutbolDBContext context;
        public EquipoRepositorio(FutbolDBContext context)
        {
            this.context = context;
        }

		public IEnumerable<Equipo> GetEquipos()
        {
            return context.Equipos;
        }

  		public Equipo GetEquipo(int id)
		{
            return context.Equipos.Find(id);
		}

    }
}
