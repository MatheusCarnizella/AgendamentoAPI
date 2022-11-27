namespace AgendamentoAPI.Models;

public class Agendamento
{
    public int agendamentoId { get; set; }
    public string? agendamentoMedico { get; set; }
    public DateTime agendamentoDia { get; set; }

    public int pacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    public int confirmarId { get; set; }
    public ConfirmarAgendamento? Confirmar { get; set; }
}
