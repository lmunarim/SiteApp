using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace serviceApi
{
    public class DBProduto : DbContext
    {
        public DBProduto() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString())
        {

        }
        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<Token> Tokens { get; set; }
    }
}
