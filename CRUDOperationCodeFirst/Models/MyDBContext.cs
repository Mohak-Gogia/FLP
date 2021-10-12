using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDOperationCodeFirst.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {

        }
        public DbSet<Candidate> Candidate { get; set; } 
    }
}