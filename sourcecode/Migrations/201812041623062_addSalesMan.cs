namespace sourcecode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSalesMan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "SalesMan", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "SalesMan");
        }
    }
}
