namespace Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProdutoModels", "Categoria", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProdutoModels", "Categoria");
        }
    }
}
