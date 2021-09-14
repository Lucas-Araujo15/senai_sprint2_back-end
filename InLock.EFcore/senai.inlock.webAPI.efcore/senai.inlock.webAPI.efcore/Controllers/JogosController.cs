using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webAPI.efcore.Domains;
using senai.inlock.webAPI.efcore.Interfaces;
using senai.inlock.webAPI.efcore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.efcore.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }

        public JogosController()
        {
            _JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_JogoRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_JogoRepository.ListarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogo jogoCadastro)
        {
            _JogoRepository.Cadastrar(jogoCadastro);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _JogoRepository.Deletar(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(Jogo novoJogo)
        {
            if (novoJogo.IdJogo == 0 || novoJogo.NomeJogo == null || novoJogo.DescricaoJogo == null || novoJogo.ValorJogo == 0 || novoJogo.IdEstudio == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram informadas!"
                    }
                );
            }

            Jogo jogoBuscado = _JogoRepository.ListarPorId(novoJogo.IdJogo);

            if (jogoBuscado != null)
            {
                jogoBuscado.NomeJogo = novoJogo.NomeJogo;
                jogoBuscado.IdEstudio = novoJogo.IdEstudio;
                jogoBuscado.ValorJogo = novoJogo.ValorJogo;
                jogoBuscado.DescricaoJogo = novoJogo.DescricaoJogo;
                jogoBuscado.DataLancamento = novoJogo.DataLancamento;
                
                _JogoRepository.Atualizar(jogoBuscado);

                return Ok();
            }

            return NotFound(
                    new
                    {
                        mensagemErro = "Jogo não encontrado!",
                        codErro = true
                    }
                );
        }
    }
}
