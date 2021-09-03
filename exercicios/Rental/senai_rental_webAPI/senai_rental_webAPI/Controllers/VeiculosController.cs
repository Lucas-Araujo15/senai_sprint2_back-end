using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using senai_rental_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> veiculosListados = _VeiculoRepository.ListarTodos();
            return Ok(veiculosListados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain veiculoEncontrado = _VeiculoRepository.BuscarPorId(id);

            if (veiculoEncontrado == null)
            {
                return NotFound("Nenhum veículo encontrado!");
            }

            return Ok(veiculoEncontrado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _VeiculoRepository.Inserir(novoVeiculo);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _VeiculoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut]
        public IActionResult Put(VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.IdVeiculo == 0 || veiculoAtualizado.IdModelo == 0 || veiculoAtualizado.placaVeiculo == null || veiculoAtualizado.IdEmpresa == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram inseridas."
                    }
                );
            }

            VeiculoDomain veiculoVerificacao = _VeiculoRepository.BuscarPorId(veiculoAtualizado.IdVeiculo);

            if (veiculoVerificacao != null)
            {
                try
                {
                    _VeiculoRepository.Atualizar(veiculoAtualizado);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            return NotFound(
                new
                {
                    mensagemErro = "O veículo não foi encontrado",
                    codErro = true
                });
        }

    }
}
