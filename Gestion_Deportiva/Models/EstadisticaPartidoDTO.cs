namespace Gestion_Deportiva.Models
{
    public class EstadisticaPartidoDTO
    {
        public int EstadisticaId { get; set; }
        public int JugadorId { get; set; }
        public int PartidoId { get; set; }

        // Jugador
        public string JugadorNombre { get; set; }
        public string NumeroCamisa { get; set; }
        public string EquipoNombre { get; set; }

        // Rendimiento
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public decimal Minutos_Jugados { get; set; }
        public int Pases_Completados { get; set; }
        public int Faltas_Cometidas { get; set; }
        public int Faltas_Recibidas { get; set; }
        public int Tarjetas_Amarillas { get; set; }
        public int Tarjetas_Rojas { get; set; }

        // Partido
        public DateTime Fecha_Hora { get; set; }
        public string Jornada { get; set; }

        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
    }
}
