using AgendamentoAPI.Context;
using AgendamentoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    public async Task<Paciente?> GetById(Expression<Func<Paciente, bool>> predicate)
    {
        Paciente? paciente = await _context.Set<Paciente>().SingleOrDefaultAsync(predicate);
        return paciente;
    }

    public async Task Post(Paciente entity)
    {
         _context.Set<Paciente>().Add(entity);
         await _context.SaveChangesAsync();
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
