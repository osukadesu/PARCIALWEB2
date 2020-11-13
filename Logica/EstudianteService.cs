using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class EstudianteService
    {
         private readonly ParcialContext _context;

       public GuardarEstudianteResponse Guardar(Estudiante estudiante)
        {
            try
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();
                return new GuardarEstudianteResponse(estudiante);
            }
            catch (Exception e)

            {
                return new GuardarEstudianteResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaEstudianteResponse ConsultarTodos()
        {
            try
            {
                List<Estudiante> estudiantes = _context.Estudiantes.ToList();
                return new ConsultaEstudianteResponse(estudiantes);
            }
            catch (Exception e)
            {
                return new ConsultaEstudianteResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Estudiante BuscarxIdentificacion(string cedula)
        {
            Estudiante estudiante = _context.Estudiantes.Find(cedula);
            return estudiante;
        }

        public string Eliminar(string cedula)
        {
            Estudiante estudiante = new Estudiante();
            if ((estudiante = _context.Estudiantes.Find(cedula)) != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges();
                return $"Se ha eliminado estudiante.";
            }
            else
            {
                return $"No se encontro estudiante. ";
            }
        }

        public class ConsultaEstudianteResponse
        {

            public ConsultaEstudianteResponse(List<Estudiante> estudiantes)
            {
                Error = false;
                Estudiantes = estudiantes;
            }

            public ConsultaEstudianteResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Estudiante> Estudiantes { get; set; }
        }
        public class GuardarEstudianteResponse

        {

            public GuardarEstudianteResponse(Estudiante estudiante)

            {
                Error = false;

                Estudiante = estudiante;

            }



            public GuardarEstudianteResponse(string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Estudiante Estudiante { get; set; }

        }
    
    }
}