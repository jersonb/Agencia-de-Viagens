using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppMvcVda.ClassLibrary;

namespace WebAppMvcVda.Models
{
    public class Andeiro : Usuario
    {
        public Andeiro()
        {
            this.Viagens = new List<Viagem>();
            
        }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DtNascimento { get; set; }
       
        public virtual List<Viagem> Viagens { get; set; }
    }
}
