namespace AgendamentoAPI.Models;

public class Agendamento
{
    public int agendamentoId { get; set; }
    public string? agendamentoMedico { get; set; }
    public DateTime agendamentoDia { get; set; }

    public int pacienteId { get; set; }
    public ICollection<Paciente>? Paciente { get; set; }
}
