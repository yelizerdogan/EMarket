namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moduleroute : DbMigration
    {
        public override void Up()
        {
            AddColumn("Management.Modules", "RouteOrPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Management.Modules", "RouteOrPath");
        }
    }
}
