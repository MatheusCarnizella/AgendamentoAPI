namespace AgendamentoAPI.Models;

public class Paciente
{
    public int pacienteId { get; set; }
    public string? pacienteNome { get; set; }
    public int pacienteCPF { get; set; }
    public DateTime pacienteNascimento { get; set; }

    public int agendamentoId { get; set; }
    public string? agendamentoMedico { get; set; }
    public ICollection<Agendamento>? Agendamento { get; set; }
}
