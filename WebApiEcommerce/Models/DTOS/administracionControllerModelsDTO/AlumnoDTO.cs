namespace WebApiEcommerce.Models.DTOS.administracionControllerModels
{
    public class AlumnoDTO
    {

        public string Nombre { get; set; }

        public string Email { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public DateOnly FechaNacimiento { get; set; }

        public string Dni { get; set; } = null!;

        public long Telefono { get; set; }
    }
}
