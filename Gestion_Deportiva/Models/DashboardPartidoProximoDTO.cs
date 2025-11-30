namespace Gestion_Deportiva.Models
{
    public class DashboardPartidoProximoDTO
    {
        public int PartidoId { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string Descripcion { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public string Estadio { get; set; }
    }
}
