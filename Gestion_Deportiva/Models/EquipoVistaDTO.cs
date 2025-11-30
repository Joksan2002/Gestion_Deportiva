namespace Gestion_Deportiva.Models
{
    public class EquipoVistaDTO
    {
        public int EquipoId { get; set; }
        public string EquipoNombre { get; set; }
        public string EquipoDescripcion { get; set; }
        public string LigaNombre { get; set; }
        public string DeporteNombre { get; set; }
        public string PaisNombre { get; set; }
        public string Estado { get; set; }  // ← agregado
    }
}
