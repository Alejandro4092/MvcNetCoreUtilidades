using Microsoft.AspNetCore.Mvc;
using MvcNetCoreUtilidades.Helpers;

namespace MvcNetCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {
        private HelperPahtProvider helper;

        public UploadFilesController(HelperPahtProvider helper)
        {
            this.helper = helper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SubirFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SubirFile(IFormFile fichero)
        {
            string fileName = fichero.FileName;
            string path = this.helper.MapPath(fileName, Folders.Productos);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }
            string urlMostrable = this.helper.MapUrlPath(fileName, Folders.Productos);

            ViewData["MENSAJE"] = "Fichero subido con éxito";
            ViewData["PATH"] = urlMostrable;

            return View();
        }
    }
}
