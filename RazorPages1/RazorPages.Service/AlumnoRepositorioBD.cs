using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorPages.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace RazorPages.Service
{
	public class AlumnoRepositorioBD : IAlumnoRepositorio
	{
		private readonly ColegioDBContext context;

		public AlumnoRepositorioBD(ColegioDBContext context)
        {
			this.context = context;
        }

		//mismos metodos de antes solo que con acceso a la base de datos
		//ahora context es la base de datos

		public Alumno add(Alumno alumnoNuevo)
		{
			//consulta de accion
			context.Database.ExecuteSqlRaw("insertarAlumno {0}, {1}, {2}, {3}",
				alumnoNuevo.Nombre, alumnoNuevo.Email, alumnoNuevo.Foto, alumnoNuevo.CursoId);
			return alumnoNuevo;
		}

		//devuleve todos los alumnos
		public IEnumerable<Alumno> GetAllAlumnos()
		{
			return context.Alumnos.FromSqlRaw<Alumno>("select * from alumnos").ToList(); 
		
		}

		public Alumno GetAlumnoById(int id)
		{
			SqlParameter parametro = new SqlParameter("@Id", id);
			//usamos el procedimiento que tenemos en SqlManagement.
			return context.Alumnos.FromSqlRaw<Alumno>("GetAlumnoIdById @Id", parametro)
				.ToList()
				.FirstOrDefault();
		}

		//update
		public void Update(Alumno alumnoActualizado)
		{
			var alumno = context.Alumnos.Attach(alumnoActualizado);
			alumno.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

		}
		public void Add(Alumno alumnoNuevo)
		{
			alumnoNuevo.Id = ListaAlumnos.Max(a => a.Id) + 1;
			ListaAlumnos.Add(alumnoNuevo);
		}

		//eliminar, podemos usar find ya que busca sola por funcion clave
		public Alumno Delete(int idBorrar)
		{
			Alumno alumnoBorrar = context.Alumnos.Find(idBorrar);
			if (alumnoBorrar != null) { 
				context.Alumnos.Remove(alumnoBorrar);
				context.SaveChanges();
			}
			return alumnoBorrar;
		}
		//metodo
		public IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso)
		{
			IEnumerable<Alumno> consulta = context.Alumnos;
			if (curso.HasValue)
			{
				consulta = consulta.Where(a => a.CursoId == curso).ToList();
			}
			//modo predicado, a es el alias del objeto sobre el que actúa el método
			return consulta.GroupBy(a => a.CursoId)
				.Select(g => new CursoCuantos()//g es por el aGrupamiento
				{//hacemos una consulta Select por cada agrupamiento en la que creamos un objeto CursoCuantos
					Clase = g.Key.Value,
					NumAlumnos = g.Count()
				}).ToList();//el resultado lo convertimos en lista

		}

		//Metodo de busca
		public IEnumerable<Alumno> FindAlumnos(string elementoABuscar)
		{
			if (string.IsNullOrEmpty(elementoABuscar))
			{
				return context.Alumnos;
			}
			else
			{
				return context.Alumnos.Where(a => a.Nombre.Contains(elementoABuscar) || a.Email.Contains(elementoABuscar));
			}
		}


		public IEnumerable<Alumno> FindAlumnosByCurso(Curso elementoABuscar)
		{
			if (elementoABuscar == null)
			{
				return ListaAlumnos;
			}
			else
			{
				return ListaAlumnos.Where(a => a.CursoId.Equals(elementoABuscar));
			}

		}

	}

}
