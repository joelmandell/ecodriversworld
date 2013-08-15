using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataNissen.Models
{
    public class Member
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String PassHash { get; set; }
        public String Confirmed { get; set; }
        public Boolean Banned { get; set; }
    }

    public class Property
    {
        public int Id { get; set; }
        public String MemberId { get; set; }
        public String ForumTag { get; set; }
        public DateTime DateRegistered { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PostFoot { get; set; }
        
    }
}