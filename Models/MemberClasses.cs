using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataNissen.Validations;

namespace DataNissen.Models
{
    public class Member
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, Display(Prompt = "Användarnamn", Description="Användarnamn"), MaxLength(20, ErrorMessage = "{0} får vara längst {1} tecken.")]
        public String UserName { get; set; }

        [Required, Display(Name = "Lösenord"), MinLength(8, ErrorMessage="{0} får vara minst {1} tecken.")]
        [DataType(DataType.Password)]
        public String PassHash { get; set; }

        [Required, Display(Name = "E-mail"), MaxLength(30, ErrorMessage="{0} får vara längst {1} tecken.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public String Email { get; set; }

        [ScaffoldColumn(false)]
        public String Salt { get; set; }

        [ScaffoldColumn(false)]
        public String Confirmed { get; set; }

        [ScaffoldColumn(false)]
        public Boolean Banned { get; set; }
    }

    public class Property
    {
        public int Id { get; set; }
        public String MemberId { get; set; }
        public String ForumTag { get; set; }
        public DateTime DateRegistered { get; set; }

        [Required, Display(Name = "Förnamn"), MaxLength(20, ErrorMessage="{0} får vara högst {1} tecken")]
        public String FirstName { get; set; }

        [Display(Name = "Efternamn"), MaxLength(20, ErrorMessage = "Efternamnet får vara högst {1} tecken"), Required]
        public String LastName { get; set; }
        public String PostFoot { get; set; }
        
    }

    public class RegisterModel
    {
        public Property Property { get; set; }
        public Member Member { get; set; }
    }
}