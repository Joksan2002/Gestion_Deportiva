using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;
namespace Gestion_Deportiva.Services
{
    public class EstadisticaService
    {
        private readonly SqlConnectionFactory _connection;

        public EstadisticaService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }

        //Metodo para listar estadisticas
        public async Task<IEnumerable<EstadisticaVistaDTO>> ListarVistaAsync()
        {
            using var conn = _connection.CreateConnection();

            var query = "SELECT * FROM vw_Estadisticas_Jugador_Partido";

            var result = await conn.QueryAsync<EstadisticaVistaDTO>(query);

            return result;
        }

        //Metodo para registrar una nueva estadistica
        public async Task<(int tipo, string mensaje)> InsertarEstadisticaAsync(EstadisticaInsertarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@JugadorId", dto.JugadorId);
            parametros.Add("@PartidoId", dto.PartidoId);
            parametros.Add("@Goles", dto.Goles);
            parametros.Add("@Asistencias", dto.Asistencias);
            parametros.Add("@MinutosJugados", dto.MinutosJugados);
            parametros.Add("@PasesCompletados", dto.PasesCompletados);
            parametros.Add("@FaltasCometidas", dto.FaltasCometidas);
            parametros.Add("@FaltasRecibidas", dto.FaltasRecibidas);
            parametros.Add("@TarjetasAmarillas", dto.TarjetasAmarillas);
            parametros.Add("@TarjetasRojas", dto.TarjetasRojas);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Estadistica_Insertar",
                parametros,
                commandType: CommandType.StoredProcedure);

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje);
        }

        //Metodo para actualizar una estadistica
        public async Task<(int tipo, string mensaje)> ActualizarEstadisticaAsync(EstadisticaActualizarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@EstadisticaId", dto.EstadisticaId);
            parametros.Add("@Goles", dto.Goles);
            parametros.Add("@Asistencias", dto.Asistencias);
            parametros.Add("@MinutosJugados", dto.MinutosJugados);
            parametros.Add("@PasesCompletados", dto.PasesCompletados);
            parametros.Add("@FaltasCometidas", dto.FaltasCometidas);
            parametros.Add("@FaltasRecibidas", dto.FaltasRecibidas);
            parametros.Add("@TarjetasAmarillas", dto.TarjetasAmarillas);
            parametros.Add("@TarjetasRojas", dto.TarjetasRojas);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync(
                "SP_Estadistica_Actualizar",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje);
        }


        //Estadistica obtener por id
        public async Task<(int tipo, string mensaje, EstadisticaDetalleDTO data)>
        ObtenerEstadisticaPorIdAsync(int estadisticaId)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@EstadisticaId", estadisticaId);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var result = await conn.QueryFirstOrDefaultAsync<EstadisticaDetalleDTO>(
                "SP_Estadistica_ObtenerPorId",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje, result);
        }

        //Metodo para obtener estadisticas del partido
        public async Task<(int tipo, string mensaje, IEnumerable<EstadisticaPartidoDTO> data)>
         ListarPorPartidoAsync(int partidoId)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@PartidoId", partidoId);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var datos = await conn.QueryAsync<EstadisticaPartidoDTO>(
                "SP_Estadistica_ListarPorPartido",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje, datos);
        }

        //Metodo para obterner estadisticas del jugador por partido
        public async Task<(int tipo, string mensaje, IEnumerable<EstadisticaJugadorDTO> data)>
         ListarPorJugadorAsync(int jugadorId)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@JugadorId", jugadorId);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var datos = await conn.QueryAsync<EstadisticaJugadorDTO>(
                "SP_Estadistica_ListarPorJugador",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje, datos);
        }
    }
}
