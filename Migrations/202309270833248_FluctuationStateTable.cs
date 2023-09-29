namespace MonkeyShelter.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FluctuationStateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonkeyFluctuationStates",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CreatedDate = c.DateTime(nullable: false),
                    FluctuationState = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.MonkeyFluctuationStates");
        }
    }
}
