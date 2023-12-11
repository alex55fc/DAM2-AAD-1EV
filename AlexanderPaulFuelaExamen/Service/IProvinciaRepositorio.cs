namespace Service;
using Modelos;


public interface IProvinciaRepositorio
{
	IEnumerable<Provincia> GetAllProvincias();
	Provincia GetProvinciaById(int id);
	void Update(Provincia provinciaActualizada);
	void Add(Provincia provinciaNueva);
	Provincia Delete(int idBorrar);
	IEnumerable<Provincia> ObtenerProvinciasPorComunidad(int codComunidad);
	int ContarProvinciasPorComunidad(int codComunidad);
	int ObtenerSuperficieTotalComunidad(int codComunidad);
	int ObtenerTotalHabitantesComunidad(int codComunidad);

	IEnumerable<InformacionComunidad> ObtenerInformacionComunidades();


}