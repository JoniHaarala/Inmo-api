using Microsoft.AspNetCore.Identity;

namespace InmoAPI.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public int dni { get; set; }
        public string cuil { get; set; }
        public int idrol { get; set; }

    }

    public class Rol
    {
        public int IdRol { get; set; }
        public string Name { get; set; }
    }

    public class Permisos
    {
        public int IdPermisos { get; set; }
        public string tipo_permiso { get; set; }
    }
}
