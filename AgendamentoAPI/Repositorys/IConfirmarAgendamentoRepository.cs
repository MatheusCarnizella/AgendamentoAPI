using AgendamentoAPI.Models;
using System.Linq.Expressions;

namespace AgendamentoAPI.Repositorys
{
    public interface IConfirmarAgendamentoRepository
    {
        Task<List<ConfirmarAgendamento>> GetAll();
        Task<ConfirmarAgendamento?> GetById(Expression<Func<ConfirmarAgendamento, bool>> predicate);
        void Post(ConfirmarAgendamento entity);
        void Put(ConfirmarAgendamento entity);
        void Delete(ConfirmarAgendamento entity);
    }
}
