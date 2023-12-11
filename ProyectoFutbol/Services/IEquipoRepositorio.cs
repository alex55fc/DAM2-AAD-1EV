using Modelos;

namespace Services

{
    public interface IEquipoRepositorio
    {
        IEnumerable<Equipo> GetEquipos();
        //metodo que le pasamos un id y nos devuleve un equipo
        Equipo GetEquipo(int id);
    }
}