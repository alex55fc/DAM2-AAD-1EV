using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Service
{
	public class ProvinciaRepositorio : IProvinciaRepositorio


	{
		public readonly GeografiaDbContext context;
		public ProvinciaRepositorio(GeografiaDbContext context)
		{
			this.context = context;
		}


		public void Add(Provincia provinciaNueva)
		{
			throw new NotImplementedException();
		}

		public int ContarProvinciasPorComunidad(int codComunidad)
		{
			throw new NotImplementedException();
		}

		public Provincia Delete(int idBorrar)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Provincia> GetAllProvincias()
		{
			return context.Provincias.FromSqlRaw<Provincia>("SELECT * FROM Provincias").ToList();
		}

		public Provincia GetProvinciaById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Provincia> ObtenerProvinciasPorComunidad(int codComunidad)
		{
			throw new NotImplementedException();
		}

		public int ObtenerSuperficieTotalComunidad(int codComunidad)
		{
			throw new NotImplementedException();
		}

		public int ObtenerTotalHabitantesComunidad(int codComunidad)
		{
			throw new NotImplementedException();
		}

		public void Update(Provincia provinciaActualizada)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<InformacionComunidad> ObtenerInformacionComunidades()
		{
            var provinciasPorComunidad = context.Provincias.GroupBy(p => p.codComunidad)
                .Select(g => new InformacionComunidad
                {
                    Comunidad = (g.First().codComunidad - 1),
                    superficie = g.Sum(p => p.superficie),
                    numHabitantes = g.Sum(p => p.numHabitantes),
                    numProvincias = g.Count()
                });
            return provinciasPorComunidad;
        }




	}
}
