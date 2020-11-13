using System;
using Entidad;

namespace VacunaModel
{
    public class VacunaInputModel
    {
        public string IdVacuna { get; set; }

        public string Cedula { get; set; }

        public string TipoVacuna { get; set; }

        public DateTime FechaVacuna { get; set; }
    }

    public class VacunaViewModel : VacunaInputModel
    {
        public VacunaViewModel(Vacuna vacuna)
        {
            IdVacuna = vacuna.IdVacuna;
            TipoVacuna = vacuna.TipoVacuna;
            FechaVacuna = vacuna.FechaVacuna;
            Cedula = vacuna.Cedula;
        }
    }
}
