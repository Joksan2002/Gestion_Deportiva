using Gestion_Deportiva.DataBase;
using Gestion_Deportiva.Repositories;
using Gestion_Deportiva.Services;

var builder = WebApplication.CreateBuilder(args);

// -----------------------
// 1. Servicios del sistema
// -----------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // OpenAPI nativo (.NET 9)

// -----------------------
// 2. Servicios propios (Dapper)
// -----------------------
builder.Services.AddSingleton<SqlConnectionFactory>();
builder.Services.AddScoped<StoredProcedureRepository>();
builder.Services.AddScoped<JugadorService>();
builder.Services.AddScoped<EquipoService>();
builder.Services.AddScoped<PartidoService>();
builder.Services.AddScoped<EstadisticaService>();
builder.Services.AddScoped<BoletoService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<FacturasService>();
builder.Services.AddScoped<LigasService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<ClienteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Esto genera /openapi/v1.json
}

// -----------------------
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// -----------------------

app.Run();
