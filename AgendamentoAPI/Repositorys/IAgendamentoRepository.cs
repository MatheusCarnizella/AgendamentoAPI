using AgendamentoAPI.Models;
using System.Linq.Expressions;

namespace AgendamentoAPI.Repositorys
{
    public interface IAgendamentoRepository
    {
        Task<List<Agendamento>>GetAll();
        Task<Agendamento?> GetById(Expression<Func<Agendamento, bool>> predicate);
        void Post(Agendamento entity);
        void Put(Agendamento entity);
        void Delete(Agendamento entity);
    }
}
