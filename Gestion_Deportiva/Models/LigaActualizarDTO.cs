namespace Gestion_Deportiva.Models
{
    public class LigaActualizarDTO
    {
        public int LigaId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public int? DeportesId { get; set; }
        public int? PaisId { get; set; }
        public int? TipoLigaId { get; set; }
    }
}
