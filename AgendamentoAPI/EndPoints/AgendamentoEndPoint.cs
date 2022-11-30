using AgendamentoAPI.Models;
using AgendamentoAPI.Repositorys;

namespace AgendamentoAPI.EndPoints
{
    public static class AgendamentoEndPoint
    {
        public static void MapAgendamentoEndPoint(this WebApplication ep)
        {
            ep.MapPost("/agendamento/Agendar", (Agendamento agendamento, IAgendamentoRepository _repository) =>
            {
                _repository.Post(agendamento);
                return Results.Created($"/Agendar/{agendamento.agendamentoId}", agendamento);
            })
                .Produces<Agendamento>(StatusCodes.Status201Created)
                .WithName("AgendarPaciente")
                .WithTags("Agendar");

            ep.MapGet("/agendamento/pegartodosAgendamentos", async (IAgendamentoRepository _repository) =>
            await _repository.GetAll())
                .Produces<List<Agendamento>>(StatusCodes.Status200OK)
                .WithName("MostrarAgendamentos")
                .WithTags("Agendar");

            ep.MapGet("/agendamento/pegartodosAgendamentos/{Id:int}", async (int Id, IAgendamentoRepository _repository) =>
            {
                return await _repository.GetById(p => p.agendamentoId == Id);
            })
                .Produces<List<Paciente>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("MostrarAgendamentoPeloId")
                .WithTags("Agendar");

            ep.MapPut("/agendamento/atualizarAgendamento/{Id:int}", (int Id, Agendamento agendamento, IAgendamentoRepository _repository) =>
            {
                _repository.Put(agendamento);
                return Results.Ok(agendamento);
            })
                .Produces<List<Paciente>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("AtualizarAgendamentoPeloId")
                .WithTags("Agendar");

            ep.MapDelete("/agendamento/deletarAgendamento/{Id:int}", async (int Id, IAgendamentoRepository repository) =>
            {
                var delete = await repository.GetById(p => p.agendamentoId == Id);

                if (delete is null)
                {
                    return Results.NotFound("Agendamento não encontrado");
                }

                repository.Delete(delete);
                return Results.Ok(delete);
            })
                .Produces<Paciente>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("DeletarAgendamentoPeloId")
                .WithTags("Agendar");
        } 
    }
}
