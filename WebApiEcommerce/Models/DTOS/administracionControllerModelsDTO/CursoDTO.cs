namespace WebApiEcommerce.Models.DTOS.administracionControllerModels
{
    public class CursoDTO

    {

        public int IdCurso { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string Instructor { get; set; } = null!;

        public int? DuracionHoras { get; set; }

        public DateOnly? FechaInicio { get; set; }

        public DateOnly? FechaFin { get; set; }

        public int? CupoMaximo { get; set; }

        public decimal Costo { get; set; }

        public string? Nivel { get; set; }

        public string Categoria { get; set; } = null!;

        public string? Requisitos { get; set; }
    }
}
