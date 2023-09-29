namespace MonkeyShelter.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Monkeys",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false),
                    Age = c.Int(nullable: false),
                    Weight = c.Int(nullable: false),
                    EyeColor = c.String(),
                    Species = c.String(nullable: false),
                    Registered = c.String(nullable: false),
                    FavoriteFruit = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Monkeys");
        }
    }
}
