    using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Service;

namespace AlexanderPaulFuelaExamen.Pages.Provincias
{
    public class IndexModel : PageModel
    {   
        private readonly IProvinciaRepositorio provinciaRepositorio;

        public IEnumerable<Provincia> Provincias { get; set; }
        public string elementoABuscar { get; set; }
        public IndexModel(IProvinciaRepositorio provinciaRepositorio)
        {
			this.provinciaRepositorio = provinciaRepositorio;
		}
        public void OnGet()
        {
            Provincias = provinciaRepositorio.GetAllProvincias();
        }
    }
}   
