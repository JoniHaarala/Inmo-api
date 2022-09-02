namespace InmoAPI.Models
{
    public class Factura
    {
        public int id { get; set; }
        public string fechaVencimiento { get; set; }
        public int Total { get; set; }
        public string estado { get; set; }
        public string FechaFactura { get; set; }
        public string Proveedor { get; set; }
    }
    public class Idfactura
    {
        public int idfactura { get; set; }
    }
}
