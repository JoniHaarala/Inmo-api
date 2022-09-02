using System.Security.Cryptography.X509Certificates;

namespace InmoAPI.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public HashCode salt { get; set; }
        public HashCode hash { get; set; }

    }
}
