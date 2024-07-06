using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Models;

public partial class Inscripcion
{
    public int IdInscripcion { get; set; }

    public int CursoId { get; set; }

    public int AlumnoId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Alumno Alumno { get; set; } = null!;

    public virtual Curso Curso { get; set; } = null!;

    public virtual AdmUsuario? Usuario { get; set; }
}
