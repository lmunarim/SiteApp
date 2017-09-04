using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
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
