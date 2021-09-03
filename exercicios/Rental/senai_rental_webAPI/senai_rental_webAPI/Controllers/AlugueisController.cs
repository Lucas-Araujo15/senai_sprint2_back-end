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
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> alugueisListados = _AluguelRepository.ListarTodos();
            return Ok(alugueisListados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain aluguelEncontrado = _AluguelRepository.BuscarPorId(id);

            if (aluguelEncontrado == null)
            {
                return NotFound("Nenhum aluguel foi encontrado!");
            }

            return Ok(aluguelEncontrado);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _AluguelRepository.Inserir(novoAluguel);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut]
        public IActionResult Put(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.IdAluguel == 0 || aluguelAtualizado.IdVeiculo == 0 || aluguelAtualizado.IdCliente == 0 || aluguelAtualizado.valorAluguel == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram inseridas."
                    }
                );
            }

            AluguelDomain aluguelVerificacao = _AluguelRepository.BuscarPorId(aluguelAtualizado.IdAluguel);

            if (aluguelVerificacao != null)
            {
                try
                {
                    _AluguelRepository.Atualizar(aluguelAtualizado);
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
                    mensagemErro = "O registro do aluguel não foi encontrado",
                    codErro = true
                });
        }
    }
}
