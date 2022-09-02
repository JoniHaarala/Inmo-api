using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;
using System.Data;

using InmoAPI.Models;

namespace InmoAPI.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly string cadenaSQL;
        public ProveedorController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]
        [Route("ListarProveedor")]
        public IActionResult Lista()
        {

            List<Proveedor> lista = new List<Proveedor>();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_listar_proveedor", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Proveedor
                            {
                                id = Convert.ToInt32(rd["idProveedor"]),
                                Cuit = rd["CUIT"].ToString(),
                                Nombre = rd["Nombre"].ToString(),
                                Telefono = rd["Telefono"].ToString(),
                                Correo = rd["Correo"].ToString(),
                                Direccion = rd["Direccion"].ToString(),
                                pais = rd["Pais"].ToString(),
                                codPostal = rd["Cod_Postal"].ToString(),
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", total_proveedores = lista.Count(), proveedores = lista });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });

            }
        }
    }
}
