namespace SportsClub.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1903 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberActivities",
                c => new
                    {
                        Member_MemberId = c.Int(nullable: false),
                        Activity_ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_MemberId, t.Activity_ActivityId })
                .ForeignKey("dbo.Members", t => t.Member_MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityId, cascadeDelete: true)
                .Index(t => t.Member_MemberId)
                .Index(t => t.Activity_ActivityId);
            
            AlterColumn("dbo.Members", "FirstName", c => c.String());
            AlterColumn("dbo.Members", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberActivities", "Activity_ActivityId", "dbo.Activities");
            DropForeignKey("dbo.MemberActivities", "Member_MemberId", "dbo.Members");
            DropIndex("dbo.MemberActivities", new[] { "Activity_ActivityId" });
            DropIndex("dbo.MemberActivities", new[] { "Member_MemberId" });
            AlterColumn("dbo.Members", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "FirstName", c => c.String(nullable: false, maxLength: 20));
            DropTable("dbo.MemberActivities");
        }
    }
}
