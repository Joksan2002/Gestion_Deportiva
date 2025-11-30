namespace Gestion_Deportiva.Models
{
    public class BoletoPorPartidoDto
    {
        public int BoletoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Zona { get; set; }
        public string Num_Fila { get; set; }
        public int Num_Asiento { get; set; }
        public string Puerta_Acceso { get; set; }
        public double Precio { get; set; }
        public double Impuesto { get; set; }
        public string Estado { get; set; }

        public int FacturaId { get; set; }
        public double TotalFactura { get; set; }

        public int ClienteId { get; set; }
        public int PersonaId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteDNI { get; set; }

        public int? MetodoPagoId { get; set; }
        public string MetodoPagoNombre { get; set; }
        public double? Monto_Pagado { get; set; }
        public DateTime? Fecha_Pago { get; set; }
    }
}
