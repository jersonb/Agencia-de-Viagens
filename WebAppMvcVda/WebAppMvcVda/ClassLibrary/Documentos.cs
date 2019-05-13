using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMvcVda.ClassLibrary
{
    public class Documentos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string TipoDoc { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string NumDoc { get; set; }
    }
}
