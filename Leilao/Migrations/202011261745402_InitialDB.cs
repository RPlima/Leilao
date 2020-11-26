namespace Leilao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Leilao_Id = c.Int(),
                        Pessoa_Id = c.Int(),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leilao", t => t.Leilao_Id)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .Index(t => t.Leilao_Id)
                .Index(t => t.Pessoa_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.Leilao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Email = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lance", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.Lance", "Pessoa_Id", "dbo.Pessoa");
            DropForeignKey("dbo.Leilao", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.Lance", "Leilao_Id", "dbo.Leilao");
            DropIndex("dbo.Leilao", new[] { "Produto_Id" });
            DropIndex("dbo.Lance", new[] { "Produto_Id" });
            DropIndex("dbo.Lance", new[] { "Pessoa_Id" });
            DropIndex("dbo.Lance", new[] { "Leilao_Id" });
            DropTable("dbo.Pessoa");
            DropTable("dbo.Produto");
            DropTable("dbo.Leilao");
            DropTable("dbo.Lance");
        }
    }
}
