namespace AseguradoraREST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        client_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.client_ID)
                .Index(t => t.client_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidences", "client_ID", "dbo.Clients");
            DropIndex("dbo.Incidences", new[] { "client_ID" });
            DropTable("dbo.Incidences");
        }
    }
}
