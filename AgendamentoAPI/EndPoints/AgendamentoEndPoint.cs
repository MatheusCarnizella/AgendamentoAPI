using AgendamentoAPI.Models;
using AgendamentoAPI.Repositorys;

namespace AgendamentoAPI.EndPoints
{
    public static class AgendamentoEndPoint
    {
        public static void MapAgendamentoEndPoint(this WebApplication ep)
        {
            ep.MapPost("/agendamento/Agenedar", (Agendamento agendamento, IAgendamentoRepository repository) =>
            {
                repository.Post(agendamento);
                return Results.Created($"/Agendar/{agendamento.agendamentoId}", agendamento);
            })
                .Produces<Agendamento>(StatusCodes.Status201Created)
                .WithName("Agendar")
                .WithTags("Agendar");
        } 
    }
}
