namespace Gestion_Deportiva.Models
{
    public class BoletoRegistrarDTO
    {
        public int ClienteId { get; set; }
        public int PartidoId { get; set; }
        public int MetodoPagoId { get; set; }

        public DateTime Fecha { get; set; }
        public double Precio { get; set; }
        public double Impuesto { get; set; }

        public string Zona { get; set; }
        public string NumFila { get; set; }
        public int NumAsiento { get; set; }
        public string PuertaAcceso { get; set; }

        public string Estado { get; set; } = "V"; // Vendido por defecto

    }
}
