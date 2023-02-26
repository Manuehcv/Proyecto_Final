using Microsoft.AspNetCore.Mvc;
using Proyecto_final.Models;
using Proyecto_Final.Repository;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public void PostProducto(Producto CreateProduct)
        {
            ManejadorProducto.CrearProductos(CreateProduct);
        }

        [HttpPut]
        public void PutProducto(Producto ModifyProduct)
        {
            ManejadorProducto.ModificarProducto(ModifyProduct);
        }
        [HttpDelete("{idProducto}")]
        public void DeleteProducto(long idProducto)
        {
            ManejadorProducto.BorrarProducto(idProducto);
        }
        [HttpGet("{idUsuario}")]
        public List<Producto> GetProducto(long idUsuario)
        {
            return ManejadorProducto.GetProductosByUser(idUsuario);


        }
    }
}
