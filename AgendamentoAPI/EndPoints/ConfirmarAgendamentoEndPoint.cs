using AgendamentoAPI.Models;
using AgendamentoAPI.Repositorys;

namespace AgendamentoAPI.EndPoints;

public static class ConfirmarAgendamentoEndPoint
{
    public static void MapConfirmarAgendamentoEndPoint(this WebApplication ep)
    {
        ep.MapPost("/confirmarAgendamento/Confirmar", (ConfirmarAgendamento confirmar, IConfirmarAgendamentoRepository _repository) =>
        {
            _repository.Post(confirmar);
            return Results.Created($"/Confirmar/{confirmar}", confirmar);
        })
                .Produces<Agendamento>(StatusCodes.Status201Created)
                .WithName("ConfirmarPaciente")
                .WithTags("ConfirmarAgendamento");
    }
}
