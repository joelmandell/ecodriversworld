using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DataNissen.Models
{
    public class ForumModel : DbContext
    {

        public DbSet<Subject> Subject { get; set; }
        public DbSet<Thread> Thread { get; set; }
        public DbSet<Post> Post { get; set; }

    }
}