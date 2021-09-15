using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.CF.Domains
{
    [Table("Jogos")]
    public class Jogos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idJogo { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string nomeJogo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do jogo é obrigatória")]
        public string descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória")]
        public DateTime dataLancamento { get; set; }

        [Column(TypeName = "DECIMAL (10,2)")]
        [Required(ErrorMessage = "O preço do jogo é obrigatório")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "O estúdio do jogo é obrigatório")]
        public int idEstudio { get; set; }

        [ForeignKey("idEstudio")]
        public Estudios estudio { get; set; }
    }
}
