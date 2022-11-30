namespace AgendamentoAPI.Models;

public class ConfirmarAgendamento
{
    public int confirmarId { get; set; }
    public bool confirmarAgendamento { get; set; }

    public int agendamentoId { get; set; }
    public Agendamento? Agendamento { get; set; } 
}