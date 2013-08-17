using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DataNissen.Models
{
    public class MemberModel : DbContext
    {
        public DbSet<Member> Member { get; set; }
        public DbSet<Property> Property { get; set; }
    }
}