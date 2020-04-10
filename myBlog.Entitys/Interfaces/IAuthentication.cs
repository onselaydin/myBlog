using System.Threading.Tasks;
using myBlog.Models;
namespace myBlog.Interfaces
{
    public interface IAuthentication
    {
        Task<Account> Register(Account account, string password);
        Task<Account> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}