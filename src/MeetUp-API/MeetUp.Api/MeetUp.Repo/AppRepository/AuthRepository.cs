using System;
using System.Threading.Tasks;
using MeetUp.DataContext.Models;
using MeetUp.Model.Models;
using MeetUp.Repo.Contract;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Repo.AppRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.Users.AddAsync(user);
            var isAdded = await _context.SaveChangesAsync() > 0;

            if (isAdded) return user;
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.UserName == userName);
            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordHash))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != userPasswordHash[i]) return false;
                }

                return true;
            }
        }

        public async Task<bool> UserExist(string username)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == username)) return true;
            return false;
        }
    }
}