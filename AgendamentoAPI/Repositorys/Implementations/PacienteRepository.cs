using AgendamentoAPI.Context;
using AgendamentoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoAPI.Repositorys.Implementations;

public class PacienteRepository : IPacienteRepository
{
    protected ContextSeries _context;

    public PacienteRepository(ContextSeries context)
    {
        _context = context;
    }

    public async Task<List<Paciente>> GetAll()
    {
        List<Paciente> paciente = await _context.Set<Paciente>().ToListAsync();
        return paciente;
    }

    public async Task<Paciente?> GetById(int id)
    {
        Paciente? paciente = await _context.Set<Paciente>().SingleOrDefaultAsync(x => x.pacienteId == id);
        return paciente;
    }

    public async void Post(Paciente entity)
    {
         _context.Set<Paciente>().Add(entity);
         await _context.SaveChangesAsync();
    }

    public async void Put(Paciente entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<Paciente>().Update(entity);
        await _context.SaveChangesAsync();
    }
    public async void Delete(Paciente entity)
    {
        _context.Set<Paciente>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
