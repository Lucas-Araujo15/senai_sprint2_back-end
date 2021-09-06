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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet("Login")]
        public IActionResult Logar(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioEncontrado = _UsuarioRepository.BuscarPorEmailSenha(usuario.email, usuario.senha);

            if (usuarioEncontrado != null)
            {
                return Ok(usuarioEncontrado);
            }

            return NotFound("usuário não encontrado. Tente novamente.");
        }
    }
}
