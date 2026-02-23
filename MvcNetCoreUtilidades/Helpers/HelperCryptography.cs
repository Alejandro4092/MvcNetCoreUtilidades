using System.Security.Cryptography;
using System.Text;

namespace MvcNetCoreUtilidades.Helpers
{
    public class HelperCryptography
    {
        //creamos un salt
        public static string Salt { get; set; }
        //METODO PARA GENERAR UN SALT ALEATORIO
        private static string GenerateSalt()
        {
            Random random = new Random();
            string salt = "";
            for (int i = 1; i <= 500; i++)
            {
                //GENERAMOS UN NUMERO ALEATORIO
                int num = random.Next(1, 255);
                char letra = Convert.ToChar(num);
                salt += letra;
            }
            return salt;
        }
        public static string CifrarContenido(string contenido,bool comparar)
        {
            if (comparar == false)
            {
                //NO QUEREMOS COMPARAR SOLO CIFRADO
                //CREAMOS UN NUEVO SALT
                Salt = GenerateSalt();
            }
            string contenidoSalt = contenido + Salt;
            //UTILIZAMOS EL OBJETO GRANDE PARA CIFRAR
            SHA512 managed = SHA512.Create();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] salida;
            salida = encoding.GetBytes(contenidoSalt);
            //REALIZAR n ITERACIONES SOBRE EL PROPIO CIFRADO
            for(int i = 1; i <= 66; i++)
            {
                //CIFRADO SOBRE CIFRADO
                salida = managed.ComputeHash(salida);
            }
            //DEVEMOS LIBERAR LA MEMORIA
            managed.Clear();
            string resultado = encoding.GetString(salida);
            return resultado ;
        }


        //CREAMOS LOS METODOS DE TIPO STATIC
        //SIMPLEMENTE DEVOLVEMOS UN TEXTO CIFRADO
        public static string EncriptarTextoBasico(string contenido)
        {
            //EL CIFRADO SE REALIZA A NIVEL DE BYTES[]
            byte[] entrada;
            //DESPUES DE CIFRAR LOS BYTES, NOS DARA UNA SALIDA DE BYTES[]
            byte[] salida;
            UnicodeEncoding encoding = new UnicodeEncoding();
            //NECESITAMOS UN OBJETO PARA CIFRAR EL CONTENIDO
            SHA1 managed = SHA1.Create();
            //CONVERTIMOS EL TEXTO DE ENTRADA A BYTES
            entrada = encoding.GetBytes(contenido);
            //LOS OBJETOS DE CIFRAR TIENEN UN METODO LLAMADO ComputeHash() QUE RECIBEN UN ARRAY DE BYTES,REALIZAN 
            //ACCIONES INTERNAS Y DEVUELVEN EL ARRAY DE BYTES[] CIFRADO
            salida = managed.ComputeHash(entrada);
            //CONVERTIMOS LOS BYTES A TEXTO
            string resultado = encoding.GetString(salida);
            return resultado;
        }
    }
}
