using AgendamentoAPI.Models;
using AgendamentoAPI.Repositorys.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoAPI.EndPoints
{
    public static class PacienteEndPoint
    {
        public static void MapPacienteEndPoint(this WebApplication ep)
        {
            ep.MapPost("/paciente/cadastrarPaciente", (Paciente paciente, PacienteRepository repository) =>
            {
                repository.Post(paciente);
                return Results.Created($"/cadastrarPaciente/{paciente.pacienteId}", paciente); 
            })
                .Produces<Paciente>(StatusCodes.Status201Created)
                .WithName("CriarUmNovoPaciente")
                .WithTags("Pacientes");

            ep.MapGet("/paciente/pegartodosPacientes", async (PacienteRepository repository) =>
            await repository.GetAll())
                .Produces<List<Paciente>>(StatusCodes.Status200OK)
                .WithName("PegarPacientes")
                .WithTags("Pacientes");

            ep.MapGet("/paciente/pegartodosPaciente/{Id:int}", async (int Id, PacienteRepository repository) =>
            {
                return await repository.GetById(p => p.pacienteId == Id);
            })
                .Produces<List<Paciente>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("PegarPacientesPeloId")
                .WithTags("Pacientes");

            ep.MapPut("/paciente/atualizarPaciente/{Id:int}", (int Id, Paciente paciente, PacienteRepository repository) =>
            {
               var atualizar = repository.Put(paciente);
               return Results.Ok(atualizar);
            })
                .Produces<List<Paciente>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("AtualizarPacientesPeloId")
                .WithTags("Pacientes");

            ep.MapDelete("/paciente/deletarPaciente/{Id:int}", async (int Id, PacienteRepository repository) =>
            {
                var delete = await repository.GetById(p => p.pacienteId == Id);

                if (delete is null)
                {
                    return Results.NotFound("Produto não encontrado");
                }

                repository.Delete(delete);
                return Results.Ok(delete);
            })
                .Produces<Paciente>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("DeletarPacientesPeloId")
                .WithTags("Pacientes");

        }

        
    }
}
