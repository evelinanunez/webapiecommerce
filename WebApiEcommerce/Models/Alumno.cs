using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public long Telefono { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
