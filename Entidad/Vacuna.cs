using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Vacuna
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string IdVacuna { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string TipoVacuna { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaVacuna { get; set; }

        [NotMapped]
        public Estudiante Estudiante { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string Cedula { get; set; }
    }
}
