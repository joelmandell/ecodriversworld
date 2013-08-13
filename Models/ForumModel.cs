using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataNissen.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public String Title { get; set; }
    }

    public class Thread
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Boolean Locked { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Text { get; set; }
    }

}