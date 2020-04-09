namespace DatingApplication.Models
{
    public class Users
    {
        public int Id {get;set;}
        public string name {get;set;}
        public byte[] passwordHash { get; set; }    
        public byte[] passwordSalt {get;set;}
    }
}