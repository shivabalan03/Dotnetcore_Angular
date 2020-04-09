using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatingApplication.Models.Data
{
    public class AuthRepository : IAuthRepository
    {
        public DataContext _Context { get; set; }
        public AuthRepository(DataContext Context)
        {
            _Context = Context;
        }
        public async Task<Users> Login(string username, string password)
        {
            var user = _Context.Users.FirstOrDefault(x=>x.name == username);

            if(user == null)
                return null;

            if(!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0;i<ComputeHash.Length;i++)
                {
                    if(ComputeHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<Users> Register(Users users, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            users.passwordHash = passwordHash;
            users.passwordSalt = passwordSalt;

            await _Context.Users.AddAsync(users);
            await _Context.SaveChangesAsync();

            return users;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _Context.Users.AnyAsync(x=>x.name == username))
                return true;

            return false;
        }
    }
}