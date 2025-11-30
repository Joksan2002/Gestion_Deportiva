namespace Gestion_Deportiva.Models
{
    public class EquipoDetalleDTO
    {
        public int EquipoId { get; set; }
        public string EquipoNombre { get; set; }
        public string EquipoDescripcion { get; set; }
        public DateTime? FechaFundacion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public int LigaId { get; set; }
        public string LigaNombre { get; set; }
        public string DeporteNombre { get; set; }
    }
}
