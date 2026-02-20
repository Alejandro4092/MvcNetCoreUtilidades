namespace MvcNetCoreUtilidades.Helpers
{
    //Enumeracion con las carpetas dque deseemossubir ficheros
    public enum Folders {Uploads,Images,Facturas,Temporal,Productos }
    public class HelperPahtProvider
    {
        private IWebHostEnvironment hostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HelperPahtProvider(IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this.hostEnvironment = hostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        //tendremos un metodo que se encargar de resolver la ruta
        //como string cuando recibamos el fichero
        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if (folder == Folders.Facturas)
            {
                carpeta = "facturas";
            }
            else if (folder == Folders.Temporal)
            {
                carpeta = "temp";
            }
            else if (folder == Folders.Productos)
            {
                //ESTA SI CAMBIA PORQUE ES SISTEMA DE ARCHIVOS Y
                //NECESITAMOS WEB
                carpeta = "images/productos";
            }
            string rootPath = this.hostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, carpeta, fileName);
            return path;
        }
        
        public string MapUrlPath(string fileName, Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if (folder == Folders.Facturas)
            {
                carpeta = "facturas";
            }
            else if (folder == Folders.Temporal)
            {
                carpeta = "temp";
            }
            else if (folder == Folders.Productos)
            {
                //ESTA SI CAMBIA PORQUE ES SISTEMA DE ARCHIVOS Y
                //NECESITAMOS WEB
                carpeta = "images/productos";
            }
            
            var request = this.httpContextAccessor.HttpContext.Request;
            string scheme = request.Scheme;
            string host = request.Host.Value;
            string path = $"{scheme}://{host}/{carpeta}/{fileName}";
            return path;
        }
    }

}

