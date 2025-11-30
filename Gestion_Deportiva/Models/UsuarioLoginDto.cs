namespace Gestion_Deportiva.Models
{
    public class UsuarioLoginDto
    {
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string ContrasenaHash { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public int PersonaId { get; set; }
        public int? ClienteId { get; set; }
        public string NombreCompleto { get; set; }
    }
}
