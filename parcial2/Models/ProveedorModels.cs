using Entidad;
using PersonaModel;

namespace ProveedorModels
{
    public class  ProveedorInputModel:PersonaInputModel
    {
         public string IdProveedor { get; set; }
    }

    public class  ProveedorViewModel :  ProveedorInputModel
    {
        public  ProveedorViewModel( Proveedor cliente)
        {
            IdProveedor= cliente.Cedula;
            Cedula = cliente.Cedula;
            Nombre = cliente.Nombre;
            Apellido = cliente.Apellido;
            Edad = cliente.Edad;
            Sexo = cliente.Sexo;
            Email = cliente.Email;
            Telefono= cliente.Telefono;
            Ciudad = cliente.Ciudad;
        }
    }
}