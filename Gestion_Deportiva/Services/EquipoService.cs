using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;
namespace Gestion_Deportiva.Services
{
    public class EquipoService
    {
        private readonly SqlConnectionFactory _connection;

        public EquipoService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }

        // Método para listar equipos
        public async Task<IEnumerable<EquipoVistaDTO>> ListarEquiposVistaAsync()
        {
            using var conn = _connection.CreateConnection();
            var sql = "SELECT * FROM vw_Equipos_Detalle";

            var equipos = await conn.QueryAsync<EquipoVistaDTO>(sql);
            return equipos;
        }

        //Metodo para registrar un nuevo equipo
        public async Task<(int TipoMensaje, string Mensaje)> InsertarEquipoAsync(EquipoInsertarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var p = new DynamicParameters();

            p.Add("@Nombre", dto.Nombre);
            p.Add("@Descripcion", dto.Descripcion);
            p.Add("@FechaFundacion", dto.FechaFundacion);
            p.Add("@Ciudad", dto.Ciudad);
            p.Add("@Estado", dto.Estado);
            p.Add("@LigaId", dto.LigaId);

            p.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Equipo_Insertar", p, commandType: CommandType.StoredProcedure);

            return (p.Get<int>("@TipoMensaje"), p.Get<string>("@Mensaje"));
        }

        //Metodo para actualizar un equipo
        public async Task<(int TipoMensaje, string Mensaje)> ActualizarEquipoAsync(EquipoActualizarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var p = new DynamicParameters();

            p.Add("@EquipoId", dto.EquipoId);
            p.Add("@Nombre", dto.Nombre);
            p.Add("@Descripcion", dto.Descripcion);
            p.Add("@FechaFundacion", dto.FechaFundacion);
            p.Add("@Ciudad", dto.Ciudad);
            p.Add("@Estado", dto.Estado);
            p.Add("@LigaId", dto.LigaId);

            p.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Equipo_Actualizar", p, commandType: CommandType.StoredProcedure);

            return (p.Get<int>("@TipoMensaje"), p.Get<string>("@Mensaje"));
        }

        //Metodo para eliminar un equipo
        public async Task<(int TipoMensaje, string Mensaje)> EliminarEquipoAsync(int equipoId)
        {
            using var conn = _connection.CreateConnection();

            var p = new DynamicParameters();
            p.Add("@EquipoId", equipoId);

            p.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Equipo_Eliminar", p, commandType: CommandType.StoredProcedure);

            return (p.Get<int>("@TipoMensaje"), p.Get<string>("@Mensaje"));
        }

        //Metodo para obtener un equipo por su ID
        public async Task<(EquipoDetalleDTO Data, int TipoMensaje, string Mensaje)> ObtenerEquipoPorIdAsync(int equipoId)
        {
            using var conn = _connection.CreateConnection();

            var p = new DynamicParameters();
            p.Add("@EquipoId", equipoId);

            p.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var result = await conn.QueryFirstOrDefaultAsync<EquipoDetalleDTO>(
                "SP_Equipo_ObtenerPorId",
                p,
                commandType: CommandType.StoredProcedure
            );

            return (result, p.Get<int>("@TipoMensaje"), p.Get<string>("@Mensaje"));
        }
    }
}
