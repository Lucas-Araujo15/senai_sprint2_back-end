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
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _FilmeRepository { get; set; }

        public FilmeController()
        {
            _FilmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _FilmeRepository.ListarTodos();
            return Ok(listaFilmes);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _FilmeRepository.Cadastrar(novoFilme);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _FilmeRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
