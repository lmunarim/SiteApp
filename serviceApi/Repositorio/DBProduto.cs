using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace serviceApi
{
    public class DBProduto : DbContext
    {
        public DBProduto() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Munarim\Desktop\SiteApp\serviceApi\App_Data\DBProduto.mdf;Integrated Security=True;")
        {

        }
        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<Token> Tokens { get; set; }
    }
}
