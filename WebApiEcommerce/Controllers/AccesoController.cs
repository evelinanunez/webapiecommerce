using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Custom;
using WebApiEcommerce.Models.DTOS;
using WebApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly DbecommerceContext _dbEcommerceContext;
        private readonly Utilidades _utilidades;
        public AccesoController(DbecommerceContext dbEcommerceContext, Utilidades utilidades)
        {
            _dbEcommerceContext = dbEcommerceContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> Registrarse(UsuarioDTO objeto)
        {

            var modeloUsuario = new Usuario
            {
                Nombre = objeto.Nombre,
                Correo = objeto.Correo,
                Clave = _utilidades.encriptarConSHA256(objeto.Clave)
            };

            await _dbEcommerceContext.Usuarios.AddAsync(modeloUsuario);
            await _dbEcommerceContext.SaveChangesAsync();

            if (modeloUsuario.IdUsuario != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _dbEcommerceContext.Usuarios
                                                    .Where(u =>
                                                        u.Correo == objeto.Correo &&
                                                        u.Clave == _utilidades.encriptarConSHA256(objeto.Clave)
                                                      ).FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioEncontrado) });
        }
    }
}

