using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Models;

public partial class AdmUsuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string Email { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
