using Microsoft.AspNetCore.Mvc;
using senai.inlock.webAPI.efcore.Domains;
using senai.inlock.webAPI.efcore.Interfaces;
using senai.inlock.webAPI.efcore.Repositories;

namespace senai.inlock.webAPI.efcore.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _EstudioRepository { get; set; }

        public EstudiosController()
        {
            _EstudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_EstudioRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_EstudioRepository.ListarPorId(id));
        }

        [HttpGet("jogos")]
        public IActionResult GetWithGames()
        {
            return Ok(_EstudioRepository.ListarComJogos());
        }

        [HttpPost]
        public IActionResult Post(Estudio estudioCadastro)
        {
            _EstudioRepository.Cadastrar(estudioCadastro);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _EstudioRepository.Deletar(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(Estudio novoEstudio)
        {
            Estudio estudioBuscado = _EstudioRepository.ListarPorId(novoEstudio.IdEstudio);

            if (estudioBuscado.NomeEstudio != null)
            {
                estudioBuscado.NomeEstudio = novoEstudio.NomeEstudio;
                _EstudioRepository.Atualizar(estudioBuscado);
            }

            return NoContent();
        }
    }
}
