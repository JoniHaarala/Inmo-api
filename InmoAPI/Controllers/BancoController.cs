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
    public class BancoController : ControllerBase
    {
        private readonly string cadenaSQL;
        public BancoController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]
        [Route("ListarBancos")]
        public IActionResult ListarBancos()
        {
            List<Banco> lista = new List<Banco>();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_listar_bancos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Banco
                            {
                                id = Convert.ToInt32(rd["IdBanco"]),
                                Nombre = rd["Nombre"].ToString(),
                                telefono = rd["telefono"].ToString(),
                                correo = rd["correo"].ToString(),
                                Direccion = rd["Direccion"].ToString(),
                                Pais = rd["Pais"].ToString(),
                                cod_postal = Convert.ToInt32(rd["cod_postal"]),
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", total_bancos = lista.Count(), bancos = lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("ListarCuentas")]
        public IActionResult ListarCuentas()
        {
            List<Cuenta_banco> lista = new List<Cuenta_banco>();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_listar_cuentas", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Cuenta_banco
                            {
                                id = Convert.ToInt32(rd["numCuenta"]),
                                tipoCuenta = rd["tipoCuenta"].ToString(),
                                moneda = rd["moneda"].ToString(),
                                CBU = rd["CBU"].ToString(),
                                saldo = Convert.ToInt32(rd["saldo"]),
                                idbanco = Convert.ToInt32(rd["idbanco"]),
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", total_cuentas = lista.Count(), cuentas = lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }
        }
    }
}
