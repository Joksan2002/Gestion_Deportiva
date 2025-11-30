using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;
namespace Gestion_Deportiva.Services
{
    public class JugadorService
    {
        private readonly SqlConnectionFactory _connection;

        public JugadorService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }

        //Método para listar jugadores
        public async Task<IEnumerable<JugadorVistaDTO>> ListarJugadoresVistaAsync()
        {
            using var conn = _connection.CreateConnection();

            var sql = "SELECT * FROM vw_jugadores_completo";

            return await conn.QueryAsync<JugadorVistaDTO>(sql);
        }

        //Metodo para registrar un nuevo jugador
        public async Task<(int TipoMensaje, string Mensaje)> RegistrarJugadorAsync(JugadorRegistrarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();

            // Persona
            parametros.Add("@PrimerNombre", dto.PrimerNombre);
            parametros.Add("@SegundoNombre", dto.SegundoNombre);
            parametros.Add("@PrimerApellido", dto.PrimerApellido);
            parametros.Add("@SegundoApellido", dto.SegundoApellido);
            parametros.Add("@Correo", dto.Correo);
            parametros.Add("@Direccion", dto.Direccion);
            parametros.Add("@NumDNI", dto.NumDNI);
            parametros.Add("@PaisId", dto.PaisId);
            parametros.Add("@Edad", dto.Edad);

            // Jugador
            parametros.Add("@DescripcionJugador", dto.DescripcionJugador);
            parametros.Add("@EstadoJugador", dto.EstadoJugador);
            parametros.Add("@NumCamisa", dto.NumCamisa);

            // Equipo 
            parametros.Add("@EquipoId", dto.EquipoId);
            parametros.Add("@FechaInicioEquipo", dto.FechaInicioEquipo);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Jugador_RegistrarCompleto", parametros, commandType: CommandType.StoredProcedure);

            var tm = parametros.Get<int>("@TipoMensaje");
            var msg = parametros.Get<string>("@Mensaje");

            return (tm, msg);
        }

        //Metodo para actualizar un jugador
        public async Task<(int TipoMensaje, string Mensaje)> ActualizarJugadorAsync(JugadorActualizarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var p = new DynamicParameters();

            p.Add("@JugadorId", dto.JugadorId);
            p.Add("@Descripcion", dto.Descripcion);
            p.Add("@Estado", dto.Estado);
            p.Add("@NumCamisa", dto.NumCamisa);

            p.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Mensaje", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Jugador_Actualizar", p, commandType: CommandType.StoredProcedure);

            return (p.Get<int>("@TipoMensaje"), p.Get<string>("@Mensaje"));
        }

        //Metodo para eliminar un jugador
        public async Task<(int TipoMensaje, string Mensaje)> EliminarJugadorAsync(int jugadorId)
        {
            using var conn = _connection.CreateConnection();

            var p = new DynamicParameters();
            p.Add("@JugadorId", jugadorId);

            p.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Jugador_Eliminar", p, commandType: CommandType.StoredProcedure);

            return (p.Get<int>("@TipoMensaje"), p.Get<string>("@Mensaje"));
        }

        //Metodo para obtener el detalle de un jugador por su ID
        public async Task<(JugadorDetalleDTO Data, int TipoMensaje, string Mensaje)> ObtenerJugadorPorIdAsync(int jugadorId)
        {
            using var conn = _connection.CreateConnection();

            var p = new DynamicParameters();
            p.Add("@JugadorId", jugadorId);

            p.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var result = await conn.QueryFirstOrDefaultAsync<JugadorDetalleDTO>(
                "SP_Jugador_ObtenerPorId",
                p,
                commandType: CommandType.StoredProcedure
            );

            return (result, p.Get<int>("@TipoMensaje"), p.Get<string>("@Mensaje"));
        }

        //Metodo para listar jugadores por equipo
        public async Task<(IEnumerable<JugadorPorEquipoDTO> Data, int TipoMensaje, string Mensaje)>
           ListarPorEquipoAsync(int equipoId)
        {
            using var conn = _connection.CreateConnection();

            var p = new DynamicParameters();
            p.Add("@EquipoId", equipoId);

            p.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var result = await conn.QueryAsync<JugadorPorEquipoDTO>(
                "SP_Jugador_ListarPorEquipo",
                p,
                commandType: CommandType.StoredProcedure
            );

            return (result, p.Get<int>("@TipoMensaje"), p.Get<string>("@Mensaje"));
        }

    }
}
