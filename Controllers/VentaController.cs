using Microsoft.AspNetCore.Http;
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
    }
}
