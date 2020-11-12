using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Proveedor : Persona
    {
        [Column(TypeName = "varchar(12)")]
        public string IdProveedor { get; set; }
    }
}