using Microsoft.AspNetCore.Mvc;
using Modelos;
using Service;

namespace AlexanderPaulFuelaExamen.Components
{
	public class ComunidadViewComponent : ViewComponent
	{
		public IProvinciaRepositorio provinciaRepositorio { get; set; }
		public ComunidadViewComponent(IProvinciaRepositorio provinciaRepositorio)
		{
			this.provinciaRepositorio = provinciaRepositorio;
		}

        public IViewComponentResult Invoke()
        {
            return View(provinciaRepositorio.ObtenerInformacionComunidades());
        }
			

    }
}
