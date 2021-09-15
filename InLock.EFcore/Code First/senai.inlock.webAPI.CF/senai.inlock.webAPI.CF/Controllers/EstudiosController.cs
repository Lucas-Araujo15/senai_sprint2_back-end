using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webAPI.CF.Domains;
using senai.inlock.webAPI.CF.Interfaces;
using senai.inlock.webAPI.CF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.CF.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _EstudioRepository { get; set; }

        public EstudiosController()
        {
            _EstudioRepository = new EstudiosRepository();
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
        public IActionResult Post(Estudios estudioCadastro)
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
        public IActionResult Put(Estudios novoEstudio)
        {
            Estudios estudioBuscado = _EstudioRepository.ListarPorId(novoEstudio.idEstudio);

            if (estudioBuscado.nomeEstudio != null)
            {
                estudioBuscado.nomeEstudio = novoEstudio.nomeEstudio;
                _EstudioRepository.Atualizar(estudioBuscado);
            }

            return NoContent();
        }
    }
}
