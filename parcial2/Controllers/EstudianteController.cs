using System.Linq;
using Datos;
using Entidad;
using EstudianteModel;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

[Route("api/[controller]")]
[ApiController]
public class EstudianteController : ControllerBase
{
    private readonly EstudianteService _estudianteService;

    public IConfiguration Configuration { get; }

    public EstudianteController(ParcialContext context)
    {
        _estudianteService = new EstudianteService(context);
    }

    // GET: api/Estudiante​
    [HttpGet]
    public ActionResult<EstudianteViewModel> Gets()
    {
        var response = _estudianteService.ConsultarTodos();
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        else
        {
            return Ok(response
                .Estudiantes
                .Select(p => new EstudianteViewModel(p)));
        }
    }

    // GET: api/Estudiante/5​
    [HttpGet("{cedula}")]
    public ActionResult<EstudianteViewModel> Get(string cedula)
    {
        var estudiante = _estudianteService.BuscarxIdentificacion(cedula);
        if (estudiante == null) return NotFound();
        var estudianteViewModel = new EstudianteViewModel(estudiante);
        return estudianteViewModel;
    }

    // POST: api/Estudiante​
    [HttpPost]
    public ActionResult<EstudianteViewModel>
    Post(EstudianteInputModel estudianteInput)
    {
        Estudiante estudiante = MapearEstudiante(estudianteInput);
        var response = _estudianteService.Guardar(estudiante);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Estudiante);
    }

    // DELETE: api/Estudiante/5​
    [HttpDelete("{cedula}")]
    public ActionResult<string> Delete(string idestudiante)
    {
        string mensaje = _estudianteService.Eliminar(idestudiante);
        return Ok(mensaje);
    }

    private Estudiante MapearEstudiante(EstudianteInputModel estudianteInput)
    {
        var estudiante =
            new Estudiante {
                Cedula = estudianteInput.Cedula,
                IdEstudiante = estudianteInput.Cedula,
                Nombre = estudianteInput.Nombre,
                Apellido = estudianteInput.Apellido,
                FechaNacimiento = estudianteInput.FechaNacimiento,
                Sexo = estudianteInput.Sexo,
                Email = estudianteInput.Email,
                Telefono = estudianteInput.Telefono,
                Colegio = estudianteInput.Colegio,
                NombreAcudiente = estudianteInput.NombreAcudiente,
            };
        return estudiante;
    }
}
