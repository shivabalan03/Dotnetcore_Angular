using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace DatingApplication.Models.Data
{
    public class seed
    {
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static void SeedUserData(DataContext dataContext)
        {
            if(!dataContext.Users.Any())
            {
                var content = File.ReadAllText("Models/Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<Users>>(content);
                foreach(var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);
                    user.name = user.name.ToLower();
                    user.passwordHash = passwordHash;
                    user.passwordSalt = passwordSalt;
                    dataContext.Users.Add(user);
                }
                dataContext.SaveChanges();
            }
        }
    }
}