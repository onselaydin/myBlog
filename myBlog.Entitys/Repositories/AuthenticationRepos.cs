using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myBlog.Data;
using myBlog.Models;
using myBlog.Interfaces;

namespace myBlog.Repositories
{
    public class AuthenticationRepos:IAuthentication
    {
        private DataContext _context;
        public AuthenticationRepos(DataContext context)
        {
            _context = context;
        }

        private byte[] StringToByteArray(string str)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetBytes(str);
        }
        private string ByteArrayToString(byte[] arr)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetString(arr);
        }
        public async Task<Account> Register(Account account, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            account.PasswordHash = ByteArrayToString(passwordHash);
            account.PasswordSalt = ByteArrayToString(passwordSalt);
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        } 
        public  async Task<Account> Login(string userName, string password)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.Nick == userName);
            if (user == null)
            {
                return null;
            }
            if(!VerifyPasswordHash(password,StringToByteArray(user.PasswordHash), StringToByteArray(user.PasswordSalt)))
            {
                return null;
            }
            return user;
        }

        public async Task<bool> UserExists(string userName)
        {
            if(await _context.Accounts.AnyAsync(x=>x.Nick == userName))
            {
                return true;
            }
            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac= new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) //kullanıcıdan gelen değer ile computed karşılaştırılıyor.
                    {
                        return false; //eşit olmayan bir durum yakalarsa false döneder.
                    }
                }
                return true;
            }
        }
        

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        

    }
}