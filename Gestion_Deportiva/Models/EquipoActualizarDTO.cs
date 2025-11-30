namespace Gestion_Deportiva.Models
{
    public class EquipoActualizarDTO
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaFundacion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public int? LigaId { get; set; }
    }
}
