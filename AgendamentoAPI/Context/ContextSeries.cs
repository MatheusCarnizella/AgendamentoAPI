using AgendamentoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoAPI.Context;

public class ContextSeries : DbContext
{
    public ContextSeries(DbContextOptions options) : base(options)
    {}

    public DbSet<Paciente>? Pacientes { get; set; }
    public DbSet<Agendamento>? Agendamentos { get; set; }
    public DbSet<ConfirmarAgendamento>? confirmarAgendamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Paciente>().HasKey(p => p.pacienteId);
        model.Entity<Paciente>().Property(p => p.pacienteNome).IsRequired();
        model.Entity<Paciente>().Property(p => p.pacienteCPF).IsRequired().HasMaxLength(11).IsFixedLength(true);
        model.Entity<Paciente>().Property(p => p.pacienteNascimento).IsRequired();

        model.Entity<Agendamento>().HasKey(a => a.agendamentoId);
        model.Entity<Agendamento>().Property(a => a.agendamentoMedico).IsRequired();
        model.Entity<Agendamento>().Property(a => a.agendamentoDia).IsRequired();

        model.Entity<ConfirmarAgendamento>().HasKey(c => c.confirmarId);
        model.Entity<ConfirmarAgendamento>().Property(c => c.confirmarAgendamento).IsRequired();

        model.Entity<Paciente>()
            .HasMany(x => x.Agendamento)
            .WithOne(x => x.Paciente)
            .HasForeignKey(x => x.agendamentoId);

        model.Entity<Agendamento>()
            .HasOne(x => x.Confirmar)
            .WithMany(x => x.Agendamento)
            .HasForeignKey(x => x.confirmarId);
    }
}
