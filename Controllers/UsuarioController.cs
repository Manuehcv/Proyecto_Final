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

        [HttpGet ("{usuario}/{contraseña}")]
        public Usuario Login(string usuario, string contraseña)
        {
            return ManejadorUsuario.Login(usuario, contraseña);
        }
        [HttpPost]
        public void PostUsuario(Usuario crearUsuario)
        {
            ManejadorUsuario.CrearUsuario(crearUsuario);
        }

        [HttpGet("{nombreUsuario}")]
        public Usuario GetUsuario(string nombreUsuario)
        {
            return ManejadorUsuario.GetUsuarioBynombreUsuario(nombreUsuario);
        }

    }
}
