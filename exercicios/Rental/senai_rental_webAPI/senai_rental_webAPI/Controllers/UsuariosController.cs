using Microsoft.AspNetCore.Authorization;
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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }
        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> usuariosListados = _UsuarioRepository.ListarTodos();
            return Ok(usuariosListados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuarioEncontrado = _UsuarioRepository.BuscarPorId(id);

            if (usuarioEncontrado == null)
            {
                return NotFound("Nenhum usuário encontrado!");
            }

            return Ok(usuarioEncontrado);
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            _UsuarioRepository.Inserir(novoUsuario);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _UsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

    }
}
