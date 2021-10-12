namespace CRUDOperationCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Candidate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhnNum = c.String(nullable: false),
                        DOB = c.String(),
                        Gender = c.String(nullable: false),
                        UnivName = c.String(nullable: false),
                        ClgName = c.String(nullable: false),
                        Branch = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Candidates");
        }
    }
}
