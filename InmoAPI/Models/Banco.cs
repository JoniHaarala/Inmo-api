using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;

namespace InmoAPI.Models
{
    public class Banco
    {
        public int id { get; set; }
		public string Nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public int cod_postal { get; set; }
		
    }
    public class Cuenta_banco
    {
        public int id { get; set; }
        public string tipoCuenta { get; set; }
        public string moneda { get; set; }
        public string CBU { get; set; }
        public int saldo { get; set; }
        public int idbanco { get; set; }
    }
}
