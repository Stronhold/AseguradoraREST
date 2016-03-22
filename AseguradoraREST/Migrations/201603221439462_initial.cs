namespace AseguradoraREST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        moneyToPay = c.Int(nullable: false),
                        Client_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.Client_ID)
                .Index(t => t.Client_ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        DNI = c.String(maxLength: 9),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        client_ID = c.Int(),
                        policy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.client_ID)
                .ForeignKey("dbo.Policies", t => t.policy_ID)
                .Index(t => t.client_ID)
                .Index(t => t.policy_ID);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "policy_ID", "dbo.Policies");
            DropForeignKey("dbo.Contracts", "client_ID", "dbo.Clients");
            DropForeignKey("dbo.Bills", "Client_ID", "dbo.Clients");
            DropIndex("dbo.Contracts", new[] { "policy_ID" });
            DropIndex("dbo.Contracts", new[] { "client_ID" });
            DropIndex("dbo.Bills", new[] { "Client_ID" });
            DropTable("dbo.Policies");
            DropTable("dbo.Contracts");
            DropTable("dbo.Clients");
            DropTable("dbo.Bills");
        }
    }
}
