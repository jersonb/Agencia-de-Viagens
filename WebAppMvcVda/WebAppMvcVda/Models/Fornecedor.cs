using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAppMvcVda.ClassLibrary;

namespace WebAppMvcVda.Models
{
    public class Fornecedor : Usuario
    {
        public Fornecedor()
        {
            this.Servicos = new List<Servico>();
        }

        [Required]
        public bool EMotorista { get; set; }
        [Required]
        public virtual List<Servico> Servicos { get; set; }
    }
}
