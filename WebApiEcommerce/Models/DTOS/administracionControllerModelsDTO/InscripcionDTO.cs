namespace WebApiEcommerce.Models.DTOS.administracionControllerModels
{
    public class InscripcionDTO
    {

        public int IdInscripcion { get; set; }

        public int CursoId { get; set; }

        public int AlumnoId { get; set; }

        public int? UsuarioId { get; set; } = null;
    }
}
