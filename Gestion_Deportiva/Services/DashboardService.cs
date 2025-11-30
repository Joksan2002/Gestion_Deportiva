using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;

namespace Gestion_Deportiva.Services
{
    public class DashboardService
    {
        private readonly SqlConnectionFactory _connection;

        public DashboardService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }

        // Obtener los contadores para el dashboard
        public async Task<DashboardContadorDTO> ObtenerDashboardAsync()
        {
            using var conn = _connection.CreateConnection();

            var result = await conn.QueryFirstAsync<DashboardContadorDTO>(
                "SP_Dashboard_Contadores",
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result;
        }

        // Obtener los próximos partidos programados
        public async Task<IEnumerable<DashboardPartidoProximoDTO>> ObtenerProximosPartidosAsync()
        {
            using var conn = _connection.CreateConnection();

            var data = await conn.QueryAsync<DashboardPartidoProximoDTO>(
                "SP_Partidos_Proximos",
                commandType: CommandType.StoredProcedure
            );

            return data;
        }

        // Obtener los resultados recientes de partidos
        public async Task<IEnumerable<DashboardPartidoResultadoDTO>> ObtenerResultadosRecientesAsync()
        {
            using var conn = _connection.CreateConnection();

            var data = await conn.QueryAsync<DashboardPartidoResultadoDTO>(
                "SP_Partidos_Resultados",
                commandType: CommandType.StoredProcedure
            );

            return data;
        }
    }
}
