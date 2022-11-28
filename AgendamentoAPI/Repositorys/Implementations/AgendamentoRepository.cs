using AgendamentoAPI.Context;
using AgendamentoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AgendamentoAPI.Repositorys.Implementations;

public class AgendamentoRepository : IAgendamentoRepository
{
    protected ContextSeries _context;

    public AgendamentoRepository(ContextSeries context)
    {
        _context = context;
    }

    public async Task<List<Agendamento>> GetAll()
    {
        List<Agendamento> agendamento = await _context.Set<Agendamento>().ToListAsync();
        return agendamento;
    }

    public async Task<Agendamento?> GetById(Expression<Func<Agendamento, bool>> predicate)
    {
        Agendamento? agendamento = await _context.Set<Agendamento>().SingleOrDefaultAsync(predicate);
        return agendamento;
    }

    public void Post(Agendamento entity)
    {
        _context.Set<Agendamento>().Add(entity);
        _context.SaveChanges();
    }

    public void Put(Agendamento entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<Agendamento>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(Agendamento entity)
    {
        _context.Set<Agendamento>().Remove(entity);
        _context.SaveChanges();
    }
}
