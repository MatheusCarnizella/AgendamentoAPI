namespace AgendamentoAPI.Models;

public class ConfirmarAgendamento
{
    public int confirmarId { get; set; }
    public bool confirmarAgendamento { get; set; }

    public ICollection<Agendamento>? Agendamento { get; set; } 
}

