namespace Gestion_Deportiva.Models
{
    public class EstadisticaInsertarDTO
    {
        public int JugadorId { get; set; }
        public int PartidoId { get; set; }
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public decimal MinutosJugados { get; set; }
        public int PasesCompletados { get; set; }
        public int FaltasCometidas { get; set; }
        public int FaltasRecibidas { get; set; }
        public int TarjetasAmarillas { get; set; }
        public int TarjetasRojas { get; set; }
    }
}
