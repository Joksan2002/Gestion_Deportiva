using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;

namespace Gestion_Deportiva.Services
{
    public class LoginService
    {
        private readonly SqlConnectionFactory _connection;

        public LoginService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto dto)
        {
            using var conn = _connection.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Usuario", dto.Usuario);

            parameters.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var usuario = await conn.QueryFirstOrDefaultAsync<UsuarioLoginDto>(
                "SP_Usuario_ObtenerPorUsuario",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            int tipoMensaje = parameters.Get<int>("@TipoMensaje");
            string mensaje = parameters.Get<string>("@Mensaje");

            //  Usuario no existe
            if (tipoMensaje != 0 || usuario == null)
            {
                return new LoginResponseDto
                {
                    TipoMensaje = tipoMensaje,
                    Mensaje = mensaje
                };
            }

            //  Usuario inactivo
            if (usuario.Estado != "A")
            {
                return new LoginResponseDto
                {
                    TipoMensaje = 1,
                    Mensaje = "Usuario inactivo"
                };
            }

            // Contraseña incorrecta
            bool passwordCorrecto = dto.Contrasena == usuario.ContrasenaHash;
            if (!passwordCorrecto)
            {
                return new LoginResponseDto
                {
                    TipoMensaje = 1,
                    Mensaje = "Contraseña incorrecta"
                };
            }

            //  Login correcto
            return new LoginResponseDto
            {
                TipoMensaje = 0,
                Mensaje = "Login exitoso",
                Usuario = usuario
            };
        }
    }

}
