using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.CF.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoUsuario { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "O título do tipo de usuário é obeigatório")]
        public string titulo { get; set; }
    }
}
