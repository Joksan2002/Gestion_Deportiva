namespace Gestion_Deportiva.Models
{
    public class EstadisticaDetalleDTO
    {
        public int EstadisticaId { get; set; }
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public decimal Minutos_Jugados { get; set; }
        public int Pases_Completados { get; set; }
        public int Faltas_Cometidas { get; set; }
        public int Faltas_Recibidas { get; set; }
        public int Tarjetas_Amarillas { get; set; }
        public int Tarjetas_Rojas { get; set; }

        // Jugador
        public int JugadorId { get; set; }
        public string JugadorNombre { get; set; }
        public string Camisa { get; set; }

        // Partido
        public int PartidoId { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string Jornada { get; set; }
        public string EstadoPartido { get; set; }

        // Equipos
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }

        // Estadio
        public string EstadioNombre { get; set; }
        public string EstadioCiudad { get; set; }
    }
}
