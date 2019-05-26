namespace GamingStore_ti2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        NIF = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Morada = c.String(nullable: false),
                        CodPostal = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientesFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClientesFK)
                .Index(t => t.ClientesFK);
            
            CreateTable(
                "dbo.Detalhes_Compra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PlataformasFK = c.Int(nullable: false),
                        JogosFK = c.Int(nullable: false),
                        ComprasFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compras", t => t.ComprasFK)
                .ForeignKey("dbo.Jogos", t => t.JogosFK)
                .ForeignKey("dbo.Plataformas", t => t.PlataformasFK)
                .Index(t => t.PlataformasFK)
                .Index(t => t.JogosFK)
                .Index(t => t.ComprasFK);
            
            CreateTable(
                "dbo.Jogos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fotografia = c.String(),
                        Plataforma = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plataformas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plataforma_Jogos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlataformasFK = c.Int(nullable: false),
                        JogosFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jogos", t => t.JogosFK)
                .ForeignKey("dbo.Plataformas", t => t.PlataformasFK)
                .Index(t => t.PlataformasFK)
                .Index(t => t.JogosFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plataforma_Jogos", "PlataformasFK", "dbo.Plataformas");
            DropForeignKey("dbo.Plataforma_Jogos", "JogosFK", "dbo.Jogos");
            DropForeignKey("dbo.Detalhes_Compra", "PlataformasFK", "dbo.Plataformas");
            DropForeignKey("dbo.Detalhes_Compra", "JogosFK", "dbo.Jogos");
            DropForeignKey("dbo.Detalhes_Compra", "ComprasFK", "dbo.Compras");
            DropForeignKey("dbo.Compras", "ClientesFK", "dbo.Clientes");
            DropIndex("dbo.Plataforma_Jogos", new[] { "JogosFK" });
            DropIndex("dbo.Plataforma_Jogos", new[] { "PlataformasFK" });
            DropIndex("dbo.Detalhes_Compra", new[] { "ComprasFK" });
            DropIndex("dbo.Detalhes_Compra", new[] { "JogosFK" });
            DropIndex("dbo.Detalhes_Compra", new[] { "PlataformasFK" });
            DropIndex("dbo.Compras", new[] { "ClientesFK" });
            DropTable("dbo.Plataforma_Jogos");
            DropTable("dbo.Plataformas");
            DropTable("dbo.Jogos");
            DropTable("dbo.Detalhes_Compra");
            DropTable("dbo.Compras");
            DropTable("dbo.Clientes");
        }
    }
}
