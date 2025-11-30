namespace Gestion_Deportiva.Models
{
    public class JugadorDetalleDTO
    {
        public int JugadorId { get; set; }

        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }

        public string Correo { get; set; }
        public string Num_DNI { get; set; }
        public int Edad { get; set; }

        public string Num_Camisa { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
    }
}
