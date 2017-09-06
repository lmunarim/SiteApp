namespace serviceApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<serviceApi.DBProduto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(serviceApi.DBProduto context)
        {
            
                context.Produtos.AddOrUpdate(
                  new ProdutoModel { Categoria = "cat1", Nome = "Leandro", Preco = 1.00M},
                  new ProdutoModel { Categoria = "cat12", Nome = "Leandro2", Preco = 1.00M },
                  new ProdutoModel { Categoria = "cat13", Nome = "Leandro3", Preco = 1.00M }
                );
            
        }
    }
}
