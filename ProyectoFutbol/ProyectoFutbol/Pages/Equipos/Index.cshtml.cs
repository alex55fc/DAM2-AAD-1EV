using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class IndexModel : PageModel
    {
        private readonly IEquipoRepositorio equiposRepositorio;

        public IEnumerable<Equipo> equipos {  get; set; }

        public IndexModel(IEquipoRepositorio equiposRepositorio)
        {
            this.equiposRepositorio = equiposRepositorio;
        }
        public void OnGet()
        {
            equipos = equiposRepositorio.GetEquipos();
        }
    }
}
