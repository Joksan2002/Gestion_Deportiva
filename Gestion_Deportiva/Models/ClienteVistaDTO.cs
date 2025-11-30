namespace Gestion_Deportiva.Models
{
    public class ClienteVistaDTO
    {
        public int IdCliente { get; set; }
        public string NombreCompleto { get; set; }
        public string NumDNI { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string NombrePais { get; set; }
        public string Usuario { get; set; }
    }
}
