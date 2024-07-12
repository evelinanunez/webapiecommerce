namespace WebApiEcommerce.Models.DTOS.administracionControllerModelsDTO
{
    public class AdmUsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string Email { get; set; } = null!;

        public string Clave { get; set; } = null!;

    }
}
