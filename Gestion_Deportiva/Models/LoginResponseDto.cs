namespace Gestion_Deportiva.Models
{
    public class LoginResponseDto
    {
        public int TipoMensaje { get; set; }
        public string Mensaje { get; set; }
        public UsuarioLoginDto Usuario { get; set; }
        public string Token { get; set; }
    }
}
