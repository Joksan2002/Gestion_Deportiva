namespace Gestion_Deportiva.Models
{
    public class JugadorRegistrarDTO
    {
        // Datos Persona
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string NumDNI { get; set; }
        public int PaisId { get; set; }
        public int Edad { get; set; }

        // Datos Jugador
        public string DescripcionJugador { get; set; }
        public string EstadoJugador { get; set; } = "A";
        public string NumCamisa { get; set; }

        // Datos Equipo
        public int? EquipoId { get; set; }
        public DateTime? FechaInicioEquipo { get; set; }
    }
}
