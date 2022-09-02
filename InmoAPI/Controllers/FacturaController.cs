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
    public class FacturaController : ControllerBase
    {
        private readonly string cadenaSQL;
        public FacturaController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]
        [Route("ListarFacturas")]
        public IActionResult Lista()
        {

            List<Factura> lista = new List<Factura>();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_listar_facturas", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    using (var rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {

                            lista.Add(new Factura
                            {
                                id = Convert.ToInt32(rd["idFactura"]),
                                fechaVencimiento = rd["fechaVencimiento"].ToString(),
                                Total = Convert.ToInt32(rd["Total"]),
                                estado = rd["estado"].ToString(),
                                FechaFactura = rd["fecha"].ToString(),
                                Proveedor = rd["proveedor"].ToString()
                            });
                        }

                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", total_Factura = lista.Count(), facturas = lista });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });

            }
        }

        // Obtener productos segun parametros establecidos
        [HttpGet]
        //[Route("Obtener")] // => Obtener?idProducto=13 | ampersand
        [Route("ObtenerPorId/{idFactura:int}")]
        public IActionResult ObtenerPorId(int idFactura)
        {

            List<Factura> lista = new List<Factura>();
            Factura oproducto = new Factura();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_listar_facturas", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {

                            lista.Add(new Factura
                            {
                                id = Convert.ToInt32(rd["idFactura"]),
                                fechaVencimiento = rd["fechaVencimiento"].ToString(),
                                Total = Convert.ToInt32(rd["Total"]),
                                estado = rd["estado"].ToString(),
                                FechaFactura = rd["fecha"].ToString(),
                                Proveedor = rd["proveedor"].ToString()
                            });
                        }

                    }
                }

                oproducto = lista.Where(item => item.id == idFactura).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oproducto });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = oproducto });

            }
        }

        [HttpGet]
        [Route("ListarIdFactura")]
        public IActionResult ListarIdFactura()
        {
            List<Idfactura> lista = new List<Idfactura>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_listar_idfactura", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Idfactura
                            {
                                idfactura = Convert.ToInt32(rd["idFactura"]),
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", total_Factura = lista.Count(), idfacturas = lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }
        }


        // agregar nuevas facturas a la base de datos de la api con el dashboard
        [HttpPost]
        [Route("GuardarFactura")]
        public IActionResult Guardar([FromBody] Factura objeto)
        {
            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_agregar_factura", conexion);
                    cmd.Parameters.AddWithValue("Categoria", objeto.fechaVencimiento);
                    cmd.Parameters.AddWithValue("Total", objeto.Total);
                    cmd.Parameters.AddWithValue("estado", objeto.estado);
                    cmd.Parameters.AddWithValue("proveedor", objeto.Proveedor);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "agregado con exito" });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }

        // Comando de api rest para editar y eliminar objetos en la base de datos
        [HttpPut]
        [Route("EditarFactura/{idFactura:int}")]
        public IActionResult EditarFactura([FromBody] Factura objeto)
        {
            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_editar_factura", conexion);
                    cmd.Parameters.AddWithValue("idFactura", objeto.id == 0 ? DBNull.Value : objeto.id);
                    cmd.Parameters.AddWithValue("Categoria", objeto.fechaVencimiento is null ? DBNull.Value : objeto.fechaVencimiento);
                    cmd.Parameters.AddWithValue("Total", objeto.Total == 0 ? DBNull.Value : objeto.Total);
                    cmd.Parameters.AddWithValue("estado", objeto.estado is null ? DBNull.Value : objeto.estado);
                    cmd.Parameters.AddWithValue("fecha", objeto.FechaFactura is null ? DBNull.Value : objeto.FechaFactura);
                    cmd.Parameters.AddWithValue("proveedor", objeto.Proveedor is null ? DBNull.Value : objeto.Proveedor);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Factura editada con exito" });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }

        //para editar estado de factura
        [HttpPut]
        [Route("EditarEstado/{idFactura:int}")]
        public IActionResult EditarEstado([FromBody] Factura objeto, int idFactura)
        {
            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_editar_estado", conexion);
                    cmd.Parameters.AddWithValue("idFactura", idFactura);
                    cmd.Parameters.AddWithValue("estado", objeto.estado is null ? DBNull.Value : objeto.estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Factura editada con exito" });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }

        [HttpDelete]
        [Route("Eliminar/{idFactura:int}")]
        public IActionResult Eliminar(int idFactura)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_borrar_factura", conexion);
                    cmd.Parameters.AddWithValue("idFactura", idFactura);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "factura eliminada" });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }
    }
}
