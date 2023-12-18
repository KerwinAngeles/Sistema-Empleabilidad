
using Capa_Datos;
using Capa_Datos.Interfaces;
using Capa_Servicios.Clases;
using Capa_Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var connectionString = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<PortalEmpleoContext>(op => op.UseSqlServer(connectionString));
builder.Services.AddScoped<IVacante, VacanteService>();
builder.Services.AddScoped<IEnviarCorreo, CorreoService>(); 
builder.Services.AddScoped<IEmpresa, EmpresaService>();
builder.Services.AddScoped<IAutenticacion, AutenticacionService>();
builder.Services.AddScoped<ISolicitante, SolicitanteService>();
builder.Services.AddScoped<INotificaciones, NotificacionService>();
builder.Services.AddScoped<IPostulacion, PostulacionService>();
builder.Services.AddScoped<IImagenes, ImagenService>();
builder.Services.AddScoped<IEmpresaObservable, EmpresaObserver>();
builder.Services.AddScoped<IContratarSolicitante, ContratarSolicitanteService>();
builder.Services.AddScoped<IData, EstadisticaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Politica");

app.UseAuthorization();

app.MapControllers();

app.Run();
