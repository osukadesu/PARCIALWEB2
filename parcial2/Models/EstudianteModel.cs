namespace parcial2.Models
{
    public class EstudianteModel
    {
        {

        public string IdEstudiante { get; set; }
        
        public string NombreAcudiente { get; set; }

        public string Apellido { get; set; }
        }

    public class EstudianteViewModel : EstudianteInputModel
    {
        public EstudianteViewModel(Estudiante estudiante)
        {
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