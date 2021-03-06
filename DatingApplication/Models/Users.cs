using System;
using System.Collections.Generic;

namespace DatingApplication.Models
{
    public class Users
    {
        public int Id {get;set;}
        public string name {get;set;}
        public byte[] passwordHash { get; set; }    
        public byte[] passwordSalt {get;set;}
        public string Gender { get; set; }
        public DateTime DateOfBirth {get;set;}
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interest { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photos> Photos { get; set; }
    }
}