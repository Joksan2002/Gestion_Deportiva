namespace Gestion_Deportiva.Models
{
    public class FacturaObtenerResponse
    {
        public int TipoMensaje { get; set; }
        public string Mensaje { get; set; }

        public FacturaObtenerPorIdDTO Factura { get; set; }
    }
}
