using AgendamentoAPI.Models;
using AgendamentoAPI.Repositorys.Implementations;

namespace AgendamentoAPI.EndPoints
{
    public static class PacienteEndPoint
    {
        public static void MapPacienteEndPoint(this WebApplication ep)
        {
            ep.MapPost("/paciente/cadastrarPaciente", (Paciente paciente, PacienteRepository repository) =>
            {
                repository.Post(paciente);                
            })
                .Produces<Paciente>(StatusCodes.Status201Created)
                .WithName("CriarUmNovoPaciente")
                .WithTags("Pacientes");

            ep.MapGet("/paciente/pegartodosPacientes", async (PacienteRepository repository) =>
            await repository.GetAll())
                .Produces<List<Paciente>>(StatusCodes.Status200OK)
                .WithName("PegarPacientes")
                .WithTags("Pacientes");

            ep.MapGet("/paciente/pegartodosPaciente/{id:int}", async (int Id, PacienteRepository repository) =>
            {
                await repository.GetById(Id);
            })
                .Produces<List<Paciente>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("PegarPacientesPeloId")
                .WithTags("Pacientes");

            ep.MapPut("/paciente/atualizarPaciente/{Id:int}", (int Id, Paciente paciente, PacienteRepository repository) =>
            {
               repository.Put(paciente);
            })
                .Produces<List<Paciente>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("AtualizarPacientesPeloId")
                .WithTags("Pacientes");

            ep.MapDelete("/paciente/excluirPaciente/{Id:int}", (int Id, Paciente paciente, PacienteRepository repository) =>
            {
                repository.Delete(paciente);
            })
                .Produces<List<Paciente>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("DeletarPacientesPeloId")
                .WithTags("Pacientes");
        }

        
    }
}
