using myBlog.Interfaces;
using myBlog.Data;
using myBlog.Models;
using myBlog.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace myBlog.Repositories
{
    public class AccountRepos : IAccount
    {
        DataContext db;
        public AccountRepos(DataContext _db)
        {
            db = _db;
        }
        public async Task<List<Account>> GetAccounts()
        {
            if (db != null)
            {
                var list = await db.Accounts.ToListAsync();
                return list;
            }

            return null;
        }
        public async Task<Account> GetAccount(int? acoountId)
        {
            if (db != null)
            {
                var rec = await db.Accounts.Where(x=>x.User_Id == acoountId).FirstOrDefaultAsync();
                return rec;
            }
            return null;
        }

        public async Task<string> AddAccount(Account account)
        {
            if (db != null)
            {
                var validator = new AccountValidator();
                var result = validator.Validate(account, ruleSet: "all");
                if(result.IsValid){
                    await db.Accounts.AddAsync(account);
                    await db.SaveChangesAsync();
                    return "OK";//account.Name;
                }else{
                    return result.Errors.FirstOrDefault().ErrorMessage;
                }
               
            }
            return "BAD";
        }

        public async Task<int> DeleteAccount(int? accountId)
        {
            int result = 0;
            if (db != null)
            {
                var rec = await db.Accounts.FirstOrDefaultAsync(x => x.User_Id == accountId);

                if (rec != null)
                {
                    db.Accounts.Remove(rec);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task UpdateAccount(Account account)
        {
            if (db != null)
            {
                db.Accounts.Update(account);
                await db.SaveChangesAsync();
            }
        }
    }
}