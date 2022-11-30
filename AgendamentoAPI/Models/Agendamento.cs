using System.Text.Json.Serialization;

namespace AgendamentoAPI.Models;

public class Agendamento
{
    public int agendamentoId { get; set; }
    public string? agendamentoMedico { get; set; }
    public DateTime agendamentoDia { get; set; }

    public int pacienteId { get; set; }
    [JsonIgnore]
    public Paciente? Paciente { get; set; }

   public ConfirmarAgendamento? Confirmar { get; set; }
}
