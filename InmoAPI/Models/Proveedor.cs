namespace InmoAPI.Models
{
    public class Proveedor
    {
        public int id { get; set; }
        public string Cuit { get; set; } 
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string pais { get; set; }
        public string codPostal { get; set; }
    }
}
