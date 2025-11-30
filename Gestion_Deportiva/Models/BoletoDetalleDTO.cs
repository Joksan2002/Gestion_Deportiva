namespace Gestion_Deportiva.Models
{
    public class BoletoDetalleDTO
    {
        // Boletos
        public int BoletoId { get; set; }
        public DateTime Fecha { get; set; }
        public double Precio { get; set; }
        public double Impuesto { get; set; }
        public string Estado { get; set; }
        public string Zona { get; set; }
        public string Num_Fila { get; set; }
        public int Num_Asiento { get; set; }
        public string Puerta_Acceso { get; set; }

        // Factura
        public int FacturaId { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public double Total { get; set; }

        // Cliente / Persona
        public int ClienteId { get; set; }
        public int PersonaId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteDNI { get; set; }

        // Partido
        public int PartidoId { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string PartidoDescripcion { get; set; }
        public string Jornada { get; set; }
        public string EstadoPartido { get; set; }

        // Equipos
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }

        // Estadio
        public int EstadioId { get; set; }
        public string EstadioNombre { get; set; }
        public string EstadioCiudad { get; set; }

        // Pago
        public int? MetodoPagoId { get; set; }
        public string MetodoPagoNombre { get; set; }
        public double? Monto_Pagado { get; set; }
        public DateTime? Fecha_Pago { get; set; }
    }
}
