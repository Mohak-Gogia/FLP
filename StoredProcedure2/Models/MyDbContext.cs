using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoredProcedure2.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=Entities")
        {
            Database.Log = Console.WriteLine;
        }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .MapToStoredProcedures(s => s.Insert(u => u.HasName("InsertCandidate", "dbo"))
                                                .Update(u => u.HasName("UpdateCandidate", "dbo"))
                                                .Delete(u => u.HasName("DeleteCandidate", "dbo"))
                );
        }
    }
}