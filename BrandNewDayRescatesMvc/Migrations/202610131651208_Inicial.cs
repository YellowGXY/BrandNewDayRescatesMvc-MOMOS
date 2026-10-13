namespace BrandNewDayRescatesMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        HeroeId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Alias = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HeroeId);
            
            CreateTable(
                "dbo.Rescates",
                c => new
                    {
                        RescateId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Villano = c.String(),
                        Resultado = c.String(),
                        HeroeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RescateId)
                .ForeignKey("dbo.Heroes", t => t.HeroeId, cascadeDelete: true)
                .Index(t => t.HeroeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rescates", "HeroeId", "dbo.Heroes");
            DropIndex("dbo.Rescates", new[] { "HeroeId" });
            DropTable("dbo.Rescates");
            DropTable("dbo.Heroes");
        }
    }
}
