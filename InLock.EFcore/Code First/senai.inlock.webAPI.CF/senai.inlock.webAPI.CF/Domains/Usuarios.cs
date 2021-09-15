using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.CF.Domains
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "O email é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo email precisa ter no mínimo 3 e no máximo 50 caracteres")]
        public string email  { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no mínimo 3 e no máximo 20 caracteres")]
        public string senha { get; set; }
        public int idTipoUsuario { get; set; }

        [ForeignKey("idTipoUsuario")]
        public TiposUsuario tipoUsuario { get; set; }
    }
}
