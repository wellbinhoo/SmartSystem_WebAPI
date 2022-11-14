using SmartSystem_WebAPI.Models;
using System.Threading.Tasks;

namespace SmartSystem_WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUNO / DEPARTAMENTO
        Task<Departamento> GetDepartamentoAsyncById(int DepartamentoId , bool _context);
        Task<Departamento[]> GetAllDepartamentosAsync(bool _context);

        //PROFESSOR  / FUNCIONARIO
        Task<Funcionario[]> GetAllFuncionarioAsync(bool includeDepartamento);
        Task<Funcionario> GetFuncionarioAsyncById(int FuncionarioId, bool includeDepartamento);
        Task<Funcionario[]> GetFuncionariosAsyncByDepartamentoId(int FuncioanrioId, bool Departamento);
    }
}
