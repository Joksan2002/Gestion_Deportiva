namespace Gestion_Deportiva.Models
{
    public class PartidoVistaDTO
    {
        public int PartidoId { get; set; }
        public DateTime Fecha_Hora { get; set; }

        public string NombreEquipoLocal { get; set; }
        public string NombreEquipoVisitante { get; set; }

        public string Jornada { get; set; }
        public string NombreEstadio { get; set; }
        public string NombreLiga { get; set; }

        public int? GolLocal { get; set; }
        public int? GolesVisitante { get; set; }
    }
}
