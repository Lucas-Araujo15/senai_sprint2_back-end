using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webAPI.CF.Domains;
using senai.inlock.webAPI.CF.Interfaces;
using senai.inlock.webAPI.CF.Repositories;

namespace senai.inlock.webAPI.CF.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _JogosRepository { get; set; }

        public JogosController()
        {
            _JogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_JogosRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_JogosRepository.ListarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogos jogoCadastro)
        {
            _JogosRepository.Cadastrar(jogoCadastro);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _JogosRepository.Deletar(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(Jogos novoJogo)
        {
            if (novoJogo.idJogo == 0 || novoJogo.nomeJogo == null || novoJogo.descricao == null || novoJogo.valor == 0 || novoJogo.idEstudio == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram informadas!"
                    }
                );
            }

            Jogos jogoBuscado = _JogosRepository.ListarPorId(novoJogo.idJogo);

            if (jogoBuscado != null)
            {
                jogoBuscado.nomeJogo = novoJogo.nomeJogo;
                jogoBuscado.idEstudio = novoJogo.idEstudio;
                jogoBuscado.valor = novoJogo.valor;
                jogoBuscado.descricao = novoJogo.descricao;
                jogoBuscado.dataLancamento = novoJogo.dataLancamento;

                _JogosRepository.Atualizar(jogoBuscado);

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
