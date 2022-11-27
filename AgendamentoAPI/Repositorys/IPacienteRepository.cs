using AgendamentoAPI.Models;

namespace AgendamentoAPI.Repositorys
{
    public interface IPacienteRepository 
    {
        Task <List<Paciente>>GetAll();
        Task<Paciente?> GetById(int id);
        void Post(Paciente entity);
        void Put(Paciente entity);
        void Delete(Paciente entity);
    }
}
