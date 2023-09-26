namespace MonkeyShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drugatabela : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonkeyFluctuationStates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MonkeyFluctuationStates");
        }
    }
}
