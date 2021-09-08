using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

        [HttpPost("Login")]
        public IActionResult Logar(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioEncontrado = _UsuarioRepository.BuscarPorEmailSenha(usuario.email, usuario.senha);

            if (usuarioEncontrado != null)
            {
                //return Ok(usuarioEncontrado);

                // Define os dados que serão fornecidos no token - payload
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.idUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioEncontrado.permissao),
                    new Claim("Claim Personalizada", "Valor teste")
                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

                // Define as credenciais do token - signature
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var myToken = new JwtSecurityToken(
                    issuer :"senai_filmes_webAPI",  // emissor do token
                    audience : "senai_filmes_webAPI", // destinatário do token
                    claims : claims,
                    expires : DateTime.Now.AddMinutes(30),
                    signingCredentials : creds
                    );
                return Ok(new 
                { 
                    token = new JwtSecurityTokenHandler().WriteToken(myToken)
                });
            }
            return NotFound("usuário não encontrado. Tente novamente.");
        }
    }
}
