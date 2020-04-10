using myBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBlog.Interfaces
{
    public interface IAccount
    {
         //Task<List<Account>> GetCategories();

        Task<List<Account>> GetAccounts();

        Task<Account> GetAccount(int? accountId);

        Task<string> AddAccount(Account post);

        Task<int> DeleteAccount(int? accountId);

        Task UpdateAccount(Account post);
    }
}