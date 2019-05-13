using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMvcVda.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
