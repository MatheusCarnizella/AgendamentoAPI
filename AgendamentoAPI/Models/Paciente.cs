using System.Text.Json.Serialization;

namespace AgendamentoAPI.Models;

public class Paciente
{
    public int pacienteId { get; set; }
    public string? pacienteNome { get; set; }
    public int pacienteCPF { get; set; }
    public DateTime pacienteNascimento { get; set; }

    [JsonIgnore]
    public int agendamentoId { get; set; }
    public ICollection<Agendamento>? Agendamento { get; set; }
}
