using AgendamentoAPI.Models;
using System.Linq.Expressions;

namespace AgendamentoAPI.Repositorys
{
    public interface IPacienteRepository 
    {
        Task<List<Paciente>>GetAll();
        Task<Paciente?> GetById(Expression<Func<Paciente, bool>> predicate);
        void Post(Paciente entity);
        void Put(Paciente entity);
        void Delete(Paciente entity);
    }
}
