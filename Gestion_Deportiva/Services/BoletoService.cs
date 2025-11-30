using Dapper;
using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Models;
using System.Data;
namespace Gestion_Deportiva.Services
{
    public class BoletoService
    {
        private readonly SqlConnectionFactory _connection;

        public BoletoService(SqlConnectionFactory connection)
        {
            _connection = connection;
        }


        //Metodo para registrar una nueva venta de boleto
        public async Task<(int tipo, string mensaje)> RegistrarVentaAsync(BoletoRegistrarDTO dto)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@ClienteId", dto.ClienteId);
            parametros.Add("@PartidoId", dto.PartidoId);
            parametros.Add("@MetodoPagoId", dto.MetodoPagoId);

            parametros.Add("@Fecha", dto.Fecha);
            parametros.Add("@Precio", dto.Precio);
            parametros.Add("@Impuesto", dto.Impuesto);
            parametros.Add("@Zona", dto.Zona);
            parametros.Add("@NumFila", dto.NumFila);
            parametros.Add("@NumAsiento", dto.NumAsiento);
            parametros.Add("@PuertaAcceso", dto.PuertaAcceso);
            parametros.Add("@Estado", dto.Estado);

            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            await conn.ExecuteAsync(
                "SP_Boleto_RegistrarVenta",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje);
        }

        //Metodo para obtener detalles de un boleto por su ID
        public async Task<(int tipo, string mensaje, BoletoDetalleDTO data)>
        ObtenerPorIdAsync(int boletoId)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@BoletoId", boletoId);
            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var resultado = await conn.QueryFirstOrDefaultAsync<BoletoDetalleDTO>(
                "SP_Boleto_ObtenerPorId",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje, resultado);
        }

        //Metodo para obtener boletos por partido
        public async Task<(int TipoMensaje, string Mensaje, IEnumerable<BoletoPorPartidoDto> Data)>
            ListarPorPartidoAsync(int partidoId)
        {
            using var conn = _connection.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@PartidoId", partidoId);
            parametros.Add("@TipoMensaje", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("@Mensaje", dbType: DbType.String, size: 300, direction: ParameterDirection.Output);

            var lista = await conn.QueryAsync<BoletoPorPartidoDto>(
                "SP_Boleto_ListarPorPartido",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            int tipo = parametros.Get<int>("@TipoMensaje");
            string mensaje = parametros.Get<string>("@Mensaje");

            return (tipo, mensaje, lista);
        }

    }
}
