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
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> clientesListados = _ClienteRepository.ListarTodos();
            return Ok(clientesListados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain clienteEncontrado = _ClienteRepository.BuscarPorId(id);

            if (clienteEncontrado == null)
            {
                return NotFound("Nenhum cliente foi encontrado!");
            }

            return Ok(clienteEncontrado);
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _ClienteRepository.Inserir(novoCliente);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ClienteRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut]
        public IActionResult Put(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.IdCliente == 0 || clienteAtualizado.nomeCliente == null || clienteAtualizado.sobrenomeCliente == null || clienteAtualizado.cpfCliente == null)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram inseridas."
                    }
                );
            }

            ClienteDomain clienteVerificacao = _ClienteRepository.BuscarPorId(clienteAtualizado.IdCliente);

            if (clienteVerificacao != null)
            {
                try
                {
                    _ClienteRepository.Atualizar(clienteAtualizado);
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
                    mensagemErro = "O cliente não foi encontrado",
                    codErro = true
                });
        }
    }
}
