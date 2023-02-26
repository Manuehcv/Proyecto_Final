using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_final.Models;
using Proyecto_Final.Repository;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public List<ProductoVendido> GetProductosVendidos(long idUsuario)
        {
            return ManejadorProductoVendido.GetProductosVendidosByUser(idUsuario);


        }
    }
}
