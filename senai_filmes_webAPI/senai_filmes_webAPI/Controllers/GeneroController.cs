using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private IGeneroRepository _GeneroRepository { get; set; }

        public GeneroController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoEncontrado = _GeneroRepository.BuscarPorId(id);

            if (generoEncontrado == null)
            {
                return NotFound("Nenhum filme encontrado!");
            }

            return Ok(generoEncontrado);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GeneroDomain> listaGeneros = _GeneroRepository.ListarTodos();
            return Ok(listaGeneros);
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            _GeneroRepository.Cadastrar(novoGenero);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _GeneroRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut]
        public IActionResult PutBody(GeneroDomain genero)
        {
            if (genero.idGenero == 0 || genero.nomeGenero == null)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram informadas!"
                    }
                );
            }
            GeneroDomain generoVerificacao = _GeneroRepository.BuscarPorId(genero.idGenero);

            if (generoVerificacao != null)
            {
                try
                {
                    _GeneroRepository.AtualizarIdCorpo(genero);
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
                        mensagemErro = "Gênero não encontrado!",
                        codErro = true
                    }
                );
        }

        [HttpPut("{id}")]
        public IActionResult PutById(int id, GeneroDomain genero)
        {
            if (id == 0 || genero.nomeGenero == null)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram informadas!"
                    }
                );
            }

            GeneroDomain generoVerificacao = _GeneroRepository.BuscarPorId(id);

            if (generoVerificacao != null)
            {
                try
                {
                    _GeneroRepository.AtualizarIdUrl(id, genero);
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
                        mensagemErro = "Gênero não encontrado!",
                        codErro = true
                    }
                );
        }
    }
}
