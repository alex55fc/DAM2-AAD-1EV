using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Service
{
	public interface IEquipoRepositorio
	{
		IEnumerable<Equipo> GetEquipos();
		Equipo GetEquip(int id);
		Equipo addEquipo(Equipo equip);

		void Update(Equipo equipo);

		Equipo Delete(int id);
		/*Falta este metodo que creo lo implemntamos para el complemneto
		IEnumerable<CategoriaCuantos> EquiposPorCategoria();
		 */
	}
}
