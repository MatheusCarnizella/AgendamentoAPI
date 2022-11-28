using AgendamentoAPI.Models;
using AgendamentoAPI.Repositorys;

namespace AgendamentoAPI.EndPoints
{
    public static class AgendamentoEndPoint
    {
        public static void MapAgendamentoEndPoint(this WebApplication ep)
        {
            ep.MapPost("/agendamento/Agendar", (Agendamento agendamento, IAgendamentoRepository repository) =>
            {
                repository.Post(agendamento);
                return Results.Created($"/Agendar/{agendamento.agendamentoId}", agendamento);
            })
                .Produces<Agendamento>(StatusCodes.Status201Created)
                .WithName("AgendarPaciente")
                .WithTags("Agendar");

            ep.MapGet("/agendamento/pegartodosAgendamentos", async (IAgendamentoRepository repository) =>
            await repository.GetAll())
           .Produces<List<Agendamento>>(StatusCodes.Status200OK)
           .WithName("MostrarAgendamentos")
           .WithTags("Agendar");
        } 
    }
}
