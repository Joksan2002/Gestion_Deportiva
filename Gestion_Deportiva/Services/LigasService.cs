using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;
namespace Gestion_Deportiva.Services
{
    public class LigasService
    {
        private readonly SqlConnectionFactory _connection;
        public LigasService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }

        // Lista de lisgas
        public async Task<IEnumerable<LigaVistaDTO>> ListarLigasVistaAsync()
        {
            using var conn = _connection.CreateConnection();
            var sql = "SELECT * FROM vw_Ligas_Completo";
            return await conn.QueryAsync<LigaVistaDTO>(sql);
        }

        // Registrar liga
        public async Task<(int tipoMensaje, string mensaje)> RegistrarLiga(LigaRegistrarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@Nombre", dto.Nombre);
            parametros.Add("@Descripcion", dto.Descripcion);
            parametros.Add("@Estado", dto.Estado);
            parametros.Add("@DeportesId", dto.DeportesId);
            parametros.Add("@PaisId", dto.PaisId);
            parametros.Add("@TipoLigaId", dto.TipoLigaId);

            parametros.Add("@TipoMensaje", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: System.Data.DbType.String, size: 300, direction: System.Data.ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Liga_Insertar", parametros, commandType: System.Data.CommandType.StoredProcedure);

            int tipoMensaje = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipoMensaje, mensaje);
        }
        // Actualizar liga
        public async Task<(int tipoMensaje, string mensaje)> ActualizarLiga(LigaActualizarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@LigaId", dto.LigaId);
            parametros.Add("@Nombre", dto.Nombre);
            parametros.Add("@Descripcion", dto.Descripcion);
            parametros.Add("@Estado", dto.Estado);
            parametros.Add("@DeportesId", dto.DeportesId);
            parametros.Add("@PaisId", dto.PaisId);
            parametros.Add("@TipoLigaId", dto.TipoLigaId);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("SP_Liga_Actualizar", parametros, commandType: CommandType.StoredProcedure);

            int tipoMensaje = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipoMensaje, mensaje);
        }

        //ligas por deporte
        public async Task<(int tipoMensaje, string mensaje, IEnumerable<dynamic> data)> ListarLigasPorDeporte(int deportesId)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@DeportesId", deportesId);
            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var resultado = await conn.QueryAsync(
                "SP_Liga_ListarPorDeporte",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipoMensaje = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipoMensaje, mensaje, resultado);
        }
    }
}
