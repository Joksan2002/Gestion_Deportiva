namespace Gestion_Deportiva.Models
{
    public class DashboardPartidoResultadoDTO
    {
        public int PartidoId { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public int Goles_Local { get; set; }
        public int Goles_Visitante { get; set; }
        public string Estadio { get; set; }
    }
}
