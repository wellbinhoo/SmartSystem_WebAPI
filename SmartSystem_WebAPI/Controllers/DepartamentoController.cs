
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSystem_WebAPI.Data;
using SmartSystem_WebAPI.Models;
using SQLitePCL;
using System;
using System.Threading.Tasks;

namespace SmartSystem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartamentoController : ControllerBase
    {
        private readonly IRepository _repo;

        public DepartamentoController(IRepository repo)
        {
            _repo = repo;
        }

        //BUSCA DE TODOS DEPARTAMENTOS.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllDepartamentosAsync(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }


        //BUSCA UNICA DE DEPARTAMENTOS
        [HttpGet("{DepartamentoId}")]
        public async Task<IActionResult> GetByDepartamentoId(int DepartamentoId)
        {
            try
            {
                var result = await _repo.GetDepartamentoAsyncById(DepartamentoId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        //ADIÇÃO DE DEPARTAMENTO
        [HttpPost]

        public async Task<IActionResult> post(Departamento Models)
        {
            try
            {
                _repo.Add(Models);

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
        //METODO DE ATUALIZAÇÃO
        [HttpPut("{DepartamentoId}")]

        public async Task<IActionResult> put(int DepartamentoId, Departamento Models)
        {
            try
            {
                var Departamento = await _repo.GetDepartamentoAsyncById(DepartamentoId, false);

                if (Departamento == null) return NotFound("Departamento não encontrado");

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
        [HttpDelete("{DepartamentoId}")]

        public async Task<IActionResult> Delete(int DepartamentoId)
        {
            try
            {
                var Departamento = await _repo.GetDepartamentoAsyncById(DepartamentoId, false);

                if (Departamento == null) return NotFound();

                _repo.Delete(Departamento);

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

    






