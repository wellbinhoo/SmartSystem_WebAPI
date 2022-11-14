
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSystem_WebAPI.Data;
using System.Threading.Tasks;
using System;
using SmartSystem_WebAPI.Models;

namespace SmartSystem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IRepository _repo;

        public FuncionarioController(IRepository repo)
        {
            _repo = repo;  
        }



        //BUSCA DE TODOS FUNCIONARIOS.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllFuncionarioAsync(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

       //BUSCA UNITARIA DE FUNCIONARIO.
        [HttpGet("{FuncinarioId}")]
        public async Task<IActionResult> GetByFuncionarioId(int FuncionarioId)
        {
            try
            {
                var result = await _repo.GetFuncionarioAsyncById(FuncionarioId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
        //BUSCA DE FUNCIONARIO POR DEPARTAMENTO.
        [HttpGet("ByDepartamento/{DepartamentoId}")]

        public async Task<IActionResult> GetDepartamentoId(int DepartamentoId)
        {
            try
            {
                var result = await _repo.GetFuncionariosAsyncByDepartamentoId(DepartamentoId, false);
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        //ADIÇAO DE FUNCIONARIO.
        [HttpPost]

        public async Task<IActionResult> post(Funcionario Models)
        {
            try
            {
                _repo.Add(Models);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(Models);
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
            return BadRequest("Erro Nao esperado!");
        }
       //METODO DE ATUALIZAÇÃO
        [HttpPut("{FuncionarioId}")]

        public async Task<IActionResult>put(int FuncionarioId,Funcionario Models)
        {
            try
            {
                var Funcionario = await _repo.GetFuncionarioAsyncById(FuncionarioId, false);

                if(Funcionario == null) return NotFound("Funcionario não encontrado");

                _repo.Update(Models);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(Models);
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
            return BadRequest("Erro Nao esperado!");
        }
        //METODO DE DELETAR
        [HttpDelete("{FuncionarioId}")]

        public async Task<IActionResult> Delete(int FuncionarioId)
        {
            try
            {
                var Funcionario = await _repo.GetFuncionarioAsyncById(FuncionarioId, false);

                if (Funcionario == null) return NotFound();

                _repo.Delete(Funcionario);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
            return BadRequest("Erro Nao esperado!");
        }


    }
}
