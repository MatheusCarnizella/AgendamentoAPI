using AgendamentoAPI.Models;
using AgendamentoAPI.Repositorys;
using AgendamentoAPI.Repositorys.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoAPI.EndPoints;

public static class PacienteEndPoint
{
    public static void MapPacienteEndPoint(this WebApplication ep)
    {
        ep.MapPost("/paciente/cadastrarPaciente", async (Paciente paciente, IPacienteRepository _repository) =>
        {
            await _repository.Post(paciente);
            return Results.Created($"/cadastrarPaciente/{paciente.pacienteId}", paciente); 
        })
            .Produces<Paciente>(StatusCodes.Status201Created)
            .WithName("CriarUmNovoPaciente")
            .WithTags("Pacientes");

        ep.MapGet("/paciente/pegartodosPacientes", async (IPacienteRepository _repository) =>
        await _repository.GetAll())
            .Produces<List<Paciente>>(StatusCodes.Status200OK)
            .WithName("PegarPacientes")
            .WithTags("Pacientes");

        ep.MapGet("/paciente/pegartodosPaciente/{Id:int}", async (int Id, IPacienteRepository _repository) =>
        {
            return await _repository.GetById(p => p.pacienteId == Id);
        })
            .Produces<List<Paciente>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("PegarPacientesPeloId")
            .WithTags("Pacientes");

        ep.MapPut("/paciente/atualizarPaciente/{Id:int}", (int Id, Paciente paciente, IPacienteRepository _repository) =>
        {
            _repository.Put(paciente);
            return Results.Ok(paciente);
        })
            .Produces<List<Paciente>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("AtualizarPacientesPeloId")
            .WithTags("Pacientes");

        ep.MapDelete("/paciente/deletarPaciente/{Id:int}", async (int Id, IPacienteRepository _repository) =>
        {
            var delete = await _repository.GetById(p => p.pacienteId == Id);

            if (delete is null)
            {
                return Results.NotFound("Produto não encontrado");
            }

            _repository.Delete(delete);
            return Results.Ok(delete);
        })
            .Produces<Paciente>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("DeletarPacientesPeloId")
            .WithTags("Pacientes");

    }

    
}
