using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEcommerce.Models;

namespace WebApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DbecommerceContext _dbEcommerceContext;

        public ProductoController(DbecommerceContext dbEcommerceContext)
        {
            _dbEcommerceContext = dbEcommerceContext;
        }
        [HttpGet]
        [Route("listarProductos")]
        public async Task<IActionResult> Lista()
        {
            var lista = await _dbEcommerceContext.Productos.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = lista });
        }
    }
}
