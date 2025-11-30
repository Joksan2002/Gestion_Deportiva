using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;
namespace Gestion_Deportiva.Services
{
    public class ClienteService
    {
        private readonly SqlConnectionFactory _connection;

        public ClienteService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }

        //Método para listar Clientes
        public async Task<IEnumerable<ClienteVistaDTO>> ListarClientesVistaAsync()
        {
            using var conn = _connection.CreateConnection();

            var sql = "SELECT * FROM vw_Clientes_Completo";

            return await conn.QueryAsync<ClienteVistaDTO>(sql);
        }

    }
}
