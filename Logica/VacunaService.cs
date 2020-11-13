using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class VacunaService
    {
        private readonly ParcialContext _context;

        public VacunaService(ParcialContext context)
        {
            _context = context;
        }
        public GuardarVacunaResponse Guardar(Vacuna vacuna)
        {
            try
            {
                _context.Vacunas.Add(vacuna);
                _context.SaveChanges();
                return new GuardarVacunaResponse(vacuna);
            }
            catch (Exception e)

            {
                return new GuardarVacunaResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaVacunaResponse ConsultarTodos()
        {
            try
            {
                List<Vacuna> vacunas = _context.Vacunas.ToList();
                return new ConsultaVacunaResponse(vacunas);
            }
            catch (Exception e)
            {
                return new ConsultaVacunaResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Vacuna BuscarxIdentificacion(string cedula)
        {
            Vacuna vacuna = _context.Vacunas.Find(cedula);
            return vacuna;
        }

        public string Eliminar(string cedula)
        {
            Vacuna vacuna = new Vacuna();
            if ((vacuna = _context.Vacunas.Find(cedula)) != null)
            {
                _context.Vacunas.Remove(vacuna);
                _context.SaveChanges();
                return $"Se ha eliminado la vacuna.";
            }
            else
            {
                return $"No se encontro la vacuna. ";
            }
        }

        public class ConsultaVacunaResponse
        {

            public ConsultaVacunaResponse(List<Vacuna> vacunas)
            {
                Error = false;
                Vacunas = vacunas;
            }

            public ConsultaVacunaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Vacuna> Vacunas { get; set; }
        }
        public class GuardarVacunaResponse

        {

            public GuardarVacunaResponse(Vacuna vacuna)

            {
                Error = false;

                Vacuna = vacuna;

            }



            public GuardarVacunaResponse(string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Vacuna Vacuna { get; set; }

        }
    }
}