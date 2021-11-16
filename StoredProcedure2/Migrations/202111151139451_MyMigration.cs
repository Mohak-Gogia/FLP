namespace StoredProcedure2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhnNum = c.String(),
                        DOB = c.String(),
                        Gender = c.String(),
                        UnivName = c.String(),
                        ClgName = c.String(),
                        Branch = c.String(),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateStoredProcedure(
                "dbo.InsertCandidate",
                p => new
                    {
                        Name = p.String(),
                        Email = p.String(),
                        PhnNum = p.String(),
                        DOB = p.String(),
                        Gender = p.String(),
                        UnivName = p.String(),
                        ClgName = p.String(),
                        Branch = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Candidates]([Name], [Email], [PhnNum], [DOB], [Gender], [UnivName], [ClgName], [Branch])
                      VALUES (@Name, @Email, @PhnNum, @DOB, @Gender, @UnivName, @ClgName, @Branch)
                      
                      DECLARE @CandidateId int
                      SELECT @CandidateId = [CandidateId]
                      FROM [dbo].[Candidates]
                      WHERE @@ROWCOUNT > 0 AND [CandidateId] = scope_identity()
                      
                      SELECT t0.[CandidateId]
                      FROM [dbo].[Candidates] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[CandidateId] = @CandidateId"
            );
            
            CreateStoredProcedure(
                "dbo.UpdateCandidate",
                p => new
                    {
                        CandidateId = p.Int(),
                        Name = p.String(),
                        Email = p.String(),
                        PhnNum = p.String(),
                        DOB = p.String(),
                        Gender = p.String(),
                        UnivName = p.String(),
                        ClgName = p.String(),
                        Branch = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Candidates]
                      SET [Name] = @Name, [Email] = @Email, [PhnNum] = @PhnNum, [DOB] = @DOB, [Gender] = @Gender, [UnivName] = @UnivName, [ClgName] = @ClgName, [Branch] = @Branch
                      WHERE ([CandidateId] = @CandidateId)"
            );
            
            CreateStoredProcedure(
                "dbo.DeleteCandidate",
                p => new
                    {
                        CandidateId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Candidates]
                      WHERE ([CandidateId] = @CandidateId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteCandidate");
            DropStoredProcedure("dbo.UpdateCandidate");
            DropStoredProcedure("dbo.InsertCandidate");
            DropTable("dbo.Candidates");
        }
    }
}
