namespace UserGroup.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TalkManyToManySpeaker : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Speakers", "Talk_Id", "dbo.Talks");
            DropIndex("dbo.Speakers", new[] {"Talk_Id"});
            CreateTable(
                "dbo.TalkSpeakers",
                c => new
                         {
                             Talk_Id = c.Int(nullable: false),
                             Speaker_Id = c.Int(nullable: false),
                         })
                .PrimaryKey(t => new {t.Talk_Id, t.Speaker_Id})
                .ForeignKey("dbo.Talks", t => t.Talk_Id, cascadeDelete: true)
                .ForeignKey("dbo.Speakers", t => t.Speaker_Id, cascadeDelete: true)
                .Index(t => t.Talk_Id)
                .Index(t => t.Speaker_Id);

            DropColumn("dbo.Speakers", "Talk_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Speakers", "Talk_Id", c => c.Int());
            DropIndex("dbo.TalkSpeakers", new[] {"Speaker_Id"});
            DropIndex("dbo.TalkSpeakers", new[] {"Talk_Id"});
            DropForeignKey("dbo.TalkSpeakers", "Speaker_Id", "dbo.Speakers");
            DropForeignKey("dbo.TalkSpeakers", "Talk_Id", "dbo.Talks");
            DropTable("dbo.TalkSpeakers");
            CreateIndex("dbo.Speakers", "Talk_Id");
            AddForeignKey("dbo.Speakers", "Talk_Id", "dbo.Talks", "Id");
        }
    }
}