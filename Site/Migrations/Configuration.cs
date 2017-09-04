namespace Site.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Site.Repositorio.DBProduto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Site.Repositorio.DBProduto context)
        {

            context.Produtos.AddOrUpdate(
              new Models.ProdutoModels{ Nome = "Prod1", Preco = 1.01M, Categoria = "Cat1" },
              new Models.ProdutoModels { Nome = "Prod2", Preco = 4.20M, Categoria = "Cat2" },
              new Models.ProdutoModels { Nome = "Prod3", Preco = 16.03M, Categoria = "Cat3" }
            );

        }
    }
}
