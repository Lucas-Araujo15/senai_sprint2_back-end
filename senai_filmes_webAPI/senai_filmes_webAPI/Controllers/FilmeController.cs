using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _FilmeRepository { get; set; }

        public FilmeController()
        {
            _FilmeRepository = new FilmeRepository();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeEncontrado = _FilmeRepository.BuscarPorId(id);

            if (filmeEncontrado == null)
            {
                return NotFound("Nenhum filme encontrado!");
            }

            return Ok(filmeEncontrado);            
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _FilmeRepository.ListarTodos();
            return Ok(listaFilmes);
        }

        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _FilmeRepository.Cadastrar(novoFilme);
            return StatusCode(201);
        }

        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _FilmeRepository.Deletar(id);
            return StatusCode(204);
        }

        [Authorize(Roles = "administrador")]
        [HttpPut]
        public IActionResult PutBody(FilmeDomain filme)
        {
            if (filme.idFilme == 0 || filme.idGenero == 0 || filme.tituloFilme == null)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram informadas!"
                    }
                );
            }

            FilmeDomain filmeVerificacao = _FilmeRepository.BuscarPorId(filme.idFilme);

            if (filmeVerificacao != null)
            {
                try
                {
                    _FilmeRepository.AtualizarIdCorpo(filme);
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
                        mensagemErro = "Filme não encontrado!",
                        codErro = true
                    }
                );
        }

        [Authorize(Roles = "administrador")]
        [HttpPut("{id}")]
        public IActionResult PutById(int id, FilmeDomain filme)
        {
            if (id == 0 || filme.idGenero == 0 || filme.tituloFilme == null)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram informadas!"
                    }
                );
            }

            FilmeDomain filmeVerificacao = _FilmeRepository.BuscarPorId(id);

            if (filmeVerificacao != null)
            {
                try
                {
                    _FilmeRepository.AtualizarIdUrl(id,filme);
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
                        mensagemErro = "Filme não encontrado!",
                        codErro = true
                    }
                );
        }
    }
}
