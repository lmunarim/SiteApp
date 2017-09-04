using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.Models;

namespace Site.Repositorio
{
    public class DBProduto : DbContext
    {
        public DbSet<ProdutoModels> Produtos { get; set; }

        public DbSet<Token> Tokens { get; set; }
    }
}
