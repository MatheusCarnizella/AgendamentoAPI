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
        await _context.SaveChangesAsync();
        return paciente;
    }

    public async Task<Paciente?> GetById(int id)
    {
        Paciente? paciente = await _context.Set<Paciente>().SingleOrDefaultAsync(x => x.pacienteId == id);
        await _context.SaveChangesAsync();
        return paciente;
    }

    public void Post(Paciente entity)
    {
         _context.Set<Paciente>().Add(entity);
         _context.SaveChanges();
    }

    public void Put(Paciente entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<Paciente>().Update(entity);
        _context.SaveChanges();
    }
    public void Delete(Paciente entity)
    {
        _context.Set<Paciente>().Remove(entity);
        _context.SaveChanges();
    }
}
