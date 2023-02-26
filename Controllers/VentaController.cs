using Microsoft.AspNetCore.Mvc;
using Proyecto_final.Models;
using Proyecto_Final.Repository;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost("{idUsuario}")]
        public void PostVenta(long idUsuario, List<Producto> listaProducto)
        {
            ManejadorVenta.CargarVenta(idUsuario, listaProducto);
        }

        [HttpGet("{idUsuario}")]
        public List<Venta> GetVentas(long idUsuario)
        {
            return ManejadorVenta.GetVentaByUser(idUsuario);


        }
    }
}
