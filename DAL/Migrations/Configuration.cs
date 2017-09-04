namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DBProduto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.DBProduto context)
        {
            context.Produtos.AddOrUpdate(
              new ProdutoModel { Nome = "produto 1", Preco = 10.00M, Categoria = "cat1"},
              new ProdutoModel { Nome = "produto 2", Preco = 10.00M, Categoria = "cat2" },
              new ProdutoModel { Nome = "produto 3", Preco = 10.00M, Categoria = "cat3" }
            );

        }
    }
}
