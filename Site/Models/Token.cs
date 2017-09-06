using System;
using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string Valor { get; set; }

        public string Usuario { get; set; }
    }
}
