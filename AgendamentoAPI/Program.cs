using AgendamentoAPI.Context;
using AgendamentoAPI.EndPoints;
using AgendamentoAPI.Repositorys;
using AgendamentoAPI.Repositorys.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DC");

builder.Services.AddDbContext<ContextSeries>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
builder.Services.AddScoped<IConfirmarAgendamentoRepository, ConfirmarAgendamentoRepository>();

var app = builder.Build();

app.MapPacienteEndPoint();
app.MapAgendamentoEndPoint();
app.MapConfirmarAgendamentoEndPoint();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

