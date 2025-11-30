namespace Gestion_Deportiva.Models
{
    public class FacturaObtenerPorIdDTO
    {
        public int FacturaId { get; set; }
        public DateTime FechaFactura { get; set; }

        // Datos del cliente
        public string NombreCompleto { get; set; }
        public string NumDNI { get; set; }
        public string Pais { get; set; }

        // Datos del boleto
        public double Precio { get; set; }
        public double Impuesto { get; set; }
        public string Zona { get; set; }
        public string NumFila { get; set; }
        public int NumAsiento { get; set; }
        public string PuertaAcceso { get; set; }
        public string EstadoBoleto { get; set; }

        // Datos del partido
        public DateTime FechaHoraPartido { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }

        // Estadio
        public string Estadio { get; set; }
        public string CiudadEstadio { get; set; }

        //Factura
        public string NombreMetodoPago { get; set; }
        public double Total { get; set; }
    }
}
