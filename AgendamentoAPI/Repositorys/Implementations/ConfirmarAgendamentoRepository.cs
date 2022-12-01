using AgendamentoAPI.Context;
using AgendamentoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AgendamentoAPI.Repositorys.Implementations;

public class ConfirmarAgendamentoRepository : IConfirmarAgendamentoRepository
{
    protected ContextSeries _context;
    public ConfirmarAgendamentoRepository(ContextSeries context)
    {
        _context = context;
    }               

    public async Task<List<ConfirmarAgendamento>> GetAll()
    {
        List<ConfirmarAgendamento> confirmar = await _context.Set<ConfirmarAgendamento>().ToListAsync();
        return confirmar;
    }

    public async Task<ConfirmarAgendamento?> GetById(Expression<Func<ConfirmarAgendamento, bool>> predicate)
    {
        ConfirmarAgendamento? confirmar = await _context.Set<ConfirmarAgendamento>().SingleOrDefaultAsync(predicate);
        return confirmar;
    }

    public void Post(ConfirmarAgendamento entity)
    {
        _context.Set<ConfirmarAgendamento>().Add(entity);
        _context.SaveChanges();
    }

    public void Put(ConfirmarAgendamento entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<ConfirmarAgendamento>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(ConfirmarAgendamento entity)
    {
        _context.Set<ConfirmarAgendamento>().Remove(entity);
        _context.SaveChanges();
    }
}