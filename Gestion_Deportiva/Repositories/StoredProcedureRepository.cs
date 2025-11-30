using Dapper;
using System.Data;
using Gestion_Deportiva.DataBase;
namespace Gestion_Deportiva.Repositories
{
    public class StoredProcedureRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public StoredProcedureRepository(SqlConnectionFactory factory)
        {
            _connectionFactory = factory;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object parameters = null)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<T>(sp, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> QueryFirstAsync<T>(string sp, object parameters = null)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(sp, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> ExecuteAsync(string sp, object parameters = null)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.ExecuteAsync(sp, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
