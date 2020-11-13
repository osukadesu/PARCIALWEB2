using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Estudiante : Persona
    {
        [Column(TypeName = "varchar(12)")]
        public string IdEstudiante { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string NombreAcudiente { get; set; }

         [Column(TypeName = "varchar(30)")]
        public string Colegio { get; set; }

        [NotMapped]
        public IList<Vacuna> Vacunas { get; set; }
    }
}
