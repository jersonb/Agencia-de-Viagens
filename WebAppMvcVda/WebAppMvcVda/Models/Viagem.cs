using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMvcVda.Models
{
    public class Viagem
    {
        public Viagem()
        {
            this.ServicosNecessarios = new List<Servico>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(200)")]
        [Required]
        public string Nome { get; set; }
        [Required]
        public bool Finalizada { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Descricao { get; set; }
        [Required]
        public virtual List<Servico> ServicosNecessarios { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DtInicio { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DtFim { get; set; }
        public bool Realisada { get; set; }
        public bool Desejada { get; set; }

    }
}
