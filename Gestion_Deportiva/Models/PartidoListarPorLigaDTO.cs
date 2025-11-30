namespace Gestion_Deportiva.Models
{
    public class PartidoListarPorLigaDTO
    {
        public int PartidoId { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Jornada { get; set; }

        // Equipos
        public int Equipo_id_Local { get; set; }
        public string EquipoLocalNombre { get; set; }

        public int Equipo_id_Visitante { get; set; }
        public string EquipoVisitanteNombre { get; set; }

        // Estadio
        public string EstadioNombre { get; set; }
        public string EstadioCiudad { get; set; }

        // Liga
        public int LigaId { get; set; }
        public string LigaNombre { get; set; }

        // Calendario
        public int Calendario_Partido_id { get; set; }
        public DateTime CalendarioInicio { get; set; }
        public DateTime CalendarioFin { get; set; }

        // Marcador
        public int? Goles_Local { get; set; }
        public int? Goles_Visitante { get; set; }
    }
}
