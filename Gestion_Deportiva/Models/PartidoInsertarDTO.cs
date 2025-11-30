namespace Gestion_Deportiva.Models
{
    public class PartidoInsertarDTO
    {
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Jornada { get; set; }

        public int CalendarioId { get; set; }
        public int EstadioId { get; set; }
        public int EquipoLocalId { get; set; }
        public int EquipoVisitanteId { get; set; }
    }
}
