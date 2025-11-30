using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;
namespace Gestion_Deportiva.Services
{
    public class FacturasService
    {
        private readonly SqlConnectionFactory _connection;

        public FacturasService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }

        // Método para obtener una factura por su ID
        public async Task<(FacturaObtenerPorIdDTO factura, int tipoMensaje, string mensaje)> ObtenerFacturaPorId(int facturaId)
        {
            using var connection = _connection.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@FacturaId", facturaId);
            parameters.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var result = await connection.QueryFirstOrDefaultAsync<FacturaObtenerPorIdDTO>(
                "SP_Factura_ObtenerPorId",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            int tipoMensaje = parameters.Get<int>("@TipoMensaje");
            string mensaje = parameters.Get<string>("@Mensaje");

            return (result, tipoMensaje, mensaje);
        }
    }
}
