using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Datos;
using VacunaModel;
using Entidad;

[Route("api/[controller]")]
[ApiController]
public class VacunaController : ControllerBase
{
    private readonly VacunaService _vacunaService;
    public IConfiguration Configuration { get; }
    public VacunaController(ParcialContext context)
    {
        _vacunaService = new VacunaService(context);
    }
    // GET: api/Vacuna​
    [HttpGet]
    public ActionResult<VacunaViewModel> Gets()
    {
        var response = _vacunaService.ConsultarTodos();
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        else
        {
            return Ok(response.Vacunas.Select(p => new VacunaViewModel(p)));
        }
    }
    // GET: api/Vacuna/5​
    [HttpGet("{idvacuna}")]
    public ActionResult<VacunaViewModel> Get(string idvacuna)
    {
        var vacuna = _vacunaService.BuscarxIdentificacion(idvacuna);
        if (vacuna == null) return NotFound();
        var vacunaViewModel = new VacunaViewModel(vacuna);
        return vacunaViewModel;
    }

    // POST: api/Vacuna​

    [HttpPost]
    public ActionResult<VacunaViewModel> Post(VacunaInputModel vacunaInput)
    {
        Vacuna vacuna = MapearVacuna(vacunaInput);
        var response = _vacunaService.Guardar(vacuna);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Vacuna);
    }

    // DELETE: api/Vacuna/5​

    [HttpDelete("{cedula}")]
    public ActionResult<string> Delete(string idvacuna)
    {
        string mensaje = _vacunaService.Eliminar(idvacuna);
        return Ok(mensaje);
    }

    private Vacuna MapearVacuna(VacunaInputModel vacunaInput)
    {
        var vacuna = new Vacuna
        {
            IdVacuna = vacunaInput.IdVacuna, 
            TipoVacuna = vacunaInput.TipoVacuna,
            FechaVacuna =vacunaInput.FechaVacuna,
        };
        return vacuna;
    }
}