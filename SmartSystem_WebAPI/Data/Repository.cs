using Microsoft.EntityFrameworkCore;
using SmartSystem_WebAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSystem_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //DEPARTAMENTO

        public async Task<Departamento[]> GetAllDepartamentosAsync(bool include_context = true)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            if (include_context)
            {
                query = query.Include(c => c);
            }
            query = query.AsNoTracking()
                         .OrderBy(Departamento => Departamento.Id);
            return await query.ToArrayAsync();
        }





        public async Task<Departamento> GetDepartamentoAsyncById(int DepartamentoId,bool include_context = true)
        {
            IQueryable<Departamento> query = _context.Departamentos;

           

            query = query.AsNoTracking()
                         .OrderBy(departamento => departamento.Id)
                         .Where(Departamento => Departamento.Id == DepartamentoId);

            return await query.FirstOrDefaultAsync();
        }
      

        //MUDEI O METODO WHERE.
        public async Task<Funcionario[]> GetFuncionariosAsyncByDepartamentoId(int DepartamentoId, bool includeDepartamento)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeDepartamento)
            {
                query = query.Include(p => p.Departamento);
                             

            }

            query = query.AsNoTracking()
                         .OrderBy(Funcionario => Funcionario.Id)
                           .Where(Departamento => Departamento.Id == DepartamentoId);


            return await query.ToArrayAsync();
        }

        public async Task<Funcionario[]> GetAllFuncionarioAsync(bool includeDepartamento = true)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeDepartamento)
            {
                query = query.Include(c => c.Departamento);
            }

            query = query.AsNoTracking()
                         .OrderBy(Funcionario => Funcionario.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Funcionario> GetFuncionarioAsyncById(int FuncionarioId, bool includeDepartamento = true)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeDepartamento)
            {
                query = query.Include(pe => pe.Departamento);
            }

            query = query.AsNoTracking()
                         .OrderBy(Funcionario => Funcionario.Id)
                         .Where(Funcionario => Funcionario.Id == FuncionarioId);

            return await query.FirstOrDefaultAsync();
        }

       
    }
}
