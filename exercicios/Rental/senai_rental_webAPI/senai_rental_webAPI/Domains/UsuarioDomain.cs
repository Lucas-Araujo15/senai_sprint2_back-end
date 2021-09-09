using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public string nomeUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string senha { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
