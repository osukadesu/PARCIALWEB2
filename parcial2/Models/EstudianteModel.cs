using System;
using Entidad;
using PersonaModel;

namespace EstudianteModel
{
     public class EstudianteInputModel : PersonaInputModel
    {
        public string IdEstudiante { get; set; }

        public string NombreAcudiente { get; set; }

         public string Colegio { get; set; }
    }

    public class EstudianteViewModel : EstudianteInputModel
    {
        public EstudianteViewModel(Estudiante estudiante)
        {
            IdEstudiante= estudiante.Cedula;
            NombreAcudiente= estudiante.NombreAcudiente;
            Colegio= estudiante.Colegio;
            Cedula = estudiante.Cedula;
            Nombre = estudiante.Nombre;
            Apellido = estudiante.Apellido;
            Email = estudiante.Email;
            FechaNacimiento = estudiante.FechaNacimiento;
            Sexo = estudiante.Sexo;
            Telefono = estudiante.Telefono;
            Ciudad = estudiante.Ciudad;
        }
    }
}