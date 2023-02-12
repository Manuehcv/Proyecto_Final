using Microsoft.AspNetCore.Mvc;
using Proyecto_final.Models;
using Proyecto_Final.Repository;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPut]
        public void PutUsuario(Usuario ModifyUser)
        {
            ManejadorUsuario.ModificarUsuario(ModifyUser);
        }
    }
}
