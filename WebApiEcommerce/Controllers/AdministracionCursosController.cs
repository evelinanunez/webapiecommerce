using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEcommerce.Custom;
using WebApiEcommerce.Models;
using WebApiEcommerce.Models.DTOS;
using WebApiEcommerce.Models.DTOS.administracionControllerModels;
using WebApiEcommerce.Models.DTOS.administracionControllerModelsDTO;

namespace WebApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AdministracionCursosController : ControllerBase
    {
        private readonly DbecommerceContext _dbEcommerceContext;
        private readonly Utilidades _utilidades;

        public AdministracionCursosController(DbecommerceContext dbEcommerceContext, Utilidades utilidades)
        {
            _dbEcommerceContext = dbEcommerceContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto )
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

        

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> Registrarse(AdmUsuarioDTO nuevoUsuario)
        {

            var modeloUsuario = new AdmUsuario {
                Nombre = nuevoUsuario.Nombre,
                Email = nuevoUsuario.Email,
                Clave = _utilidades.encriptarConSHA256(nuevoUsuario.Clave)
            };

            await _dbEcommerceContext.AdmUsuarios.AddAsync(modeloUsuario);
            await _dbEcommerceContext.SaveChangesAsync();

            if (modeloUsuario.IdUsuario != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, usuario = modeloUsuario });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpGet]
        [Route("obtenerUsuarios")]
        public async Task<IActionResult> GetUsuarios()
        {
            var listaUsuarios = await _dbEcommerceContext.AdmUsuarios.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = listaUsuarios });
        }

        [HttpPost]
        [Route("agregarAlumno")]
        public async Task<IActionResult> AgregarAlumno(AlumnoDTO nuevoAlumno)
        {
            var alumnoPorAgregar = new Alumno
            {
                Nombre = nuevoAlumno.Nombre,
                Email = nuevoAlumno.Email,
                Apellido = nuevoAlumno.Apellido,
                FechaNacimiento = nuevoAlumno.FechaNacimiento,
                Telefono = nuevoAlumno.Telefono,
                Dni = nuevoAlumno.Dni
            };

            await _dbEcommerceContext.Alumnos.AddAsync(alumnoPorAgregar);
            await _dbEcommerceContext.SaveChangesAsync();
            if (alumnoPorAgregar.IdAlumno != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpGet]
        [Route("Alumnos")]
        public async Task<IActionResult> TraerAlumnos()
        {
            var listaAlumnos = await _dbEcommerceContext.Alumnos.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = listaAlumnos });
        }

        [HttpPost]
        [Route("agregarCurso")]
        public async Task<IActionResult> AgregarCurso(CursoDTO nuevoCurso)
        {
            var nuevoCursoAAgregar = new Curso
            {
                Nombre = nuevoCurso.Nombre,
                Descripcion = nuevoCurso.Descripcion,
                Instructor = nuevoCurso.Instructor,
                DuracionHoras = nuevoCurso.DuracionHoras,
                FechaInicio = nuevoCurso.FechaInicio,
                FechaFin = nuevoCurso.FechaFin,
                CupoMaximo = nuevoCurso.CupoMaximo,
                Costo = nuevoCurso.Costo,
                Nivel = nuevoCurso.Nivel,
                Categoria = nuevoCurso.Categoria,
                Requisitos = nuevoCurso.Requisitos
            };

            await _dbEcommerceContext.Cursos.AddAsync(nuevoCursoAAgregar);
            await _dbEcommerceContext.SaveChangesAsync();

            if (nuevoCursoAAgregar.IdCurso != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpGet]
        [Route("Cursos")]
        public async Task<IActionResult> TraerCursos()
        {
            var listaAlumnos = await _dbEcommerceContext.Alumnos.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = listaAlumnos });
        }
    }
}
