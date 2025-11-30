using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;
namespace Gestion_Deportiva.Services
{
    public class PartidoService
    {
        private readonly SqlConnectionFactory _connection;

        public PartidoService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }

        //Método para listar partidos 
        public async Task<IEnumerable<PartidoVistaDTO>> ListarPartidosVistaAsync()
        {
            using var conn = _connection.CreateConnection();

            var sql = "SELECT * FROM vw_Partidos_Completos";

            var partidos = await conn.QueryAsync<PartidoVistaDTO>(sql);

            return partidos;
        }

        //Metodo para registrar un nuevo partido 
        public async Task<(int TipoMensaje, string Mensaje)> InsertarPartidoAsync(PartidoInsertarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var p = new DynamicParameters();

            p.Add("@FechaHora", dto.FechaHora);
            p.Add("@Estado", dto.Estado);
            p.Add("@Descripcion", dto.Descripcion);
            p.Add("@Jornada", dto.Jornada);
            p.Add("@CalendarioId", dto.CalendarioId);
            p.Add("@EstadioId", dto.EstadioId);
            p.Add("@EquipoLocalId", dto.EquipoLocalId);
            p.Add("@EquipoVisitanteId", dto.EquipoVisitanteId);

            p.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Partido_Insertar", p, commandType: CommandType.StoredProcedure);

            return (p.Get<int>("@TipoMensaje"), p.Get<string>("@Mensaje"));
        }

        //Metodo para actualizar un partido
        public async Task<(int tipo, string mensaje)> ActualizarPartidoAsync(PartidoActualizarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@PartidoId", dto.PartidoId);
            parametros.Add("@FechaHora", dto.FechaHora);
            parametros.Add("@Estado", dto.Estado);
            parametros.Add("@Descripcion", dto.Descripcion);
            parametros.Add("@Jornada", dto.Jornada);
            parametros.Add("@CalendarioId", dto.CalendarioId);
            parametros.Add("@EstadioId", dto.EstadioId);
            parametros.Add("@EquipoLocalId", dto.EquipoLocalId);
            parametros.Add("@EquipoVisitanteId", dto.EquipoVisitanteId);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Partido_Actualizar", parametros, commandType: CommandType.StoredProcedure);

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje);
        }

        //Metodo actualizar el resultado de un partido
        public async Task<(int tipo, string mensaje)> ActualizarMarcadorAsync(PartidoActualizarMarcadorDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@PartidoId", dto.PartidoId);
            parametros.Add("@GolesLocal", dto.GolesLocal);
            parametros.Add("@GolesVisitante", dto.GolesVisitante);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Partido_ActualizarMarcador", parametros,
                commandType: CommandType.StoredProcedure);

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje);
        }

        //Metodo para obtener los detalles de un partido por su Id
        public async Task<(int tipo, string mensaje, PartidoObtenerPorIdDTO? data)> ObtenerPartidoPorIdAsync(int partidoId)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@PartidoId", partidoId);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var result = await conn.QueryFirstOrDefaultAsync<PartidoObtenerPorIdDTO>(
                "SP_Partido_ObtenerPorId",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje, result);
        }

        //Metodo para obtener los partidos por LigaId
        public async Task<(int tipo, string mensaje, IEnumerable<PartidoListarPorLigaDTO>? data)>
        ListarPartidosPorLigaAsync(int ligaId)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@LigaId", ligaId);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var result = await conn.QueryAsync<PartidoListarPorLigaDTO>(
                "SP_Partido_ListarPorLiga",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje, result);
        }
    }
}
