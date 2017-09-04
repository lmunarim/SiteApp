using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public class DBProduto : DbContext
    {
        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<Token> Tokens { get; set; }
    }
}
