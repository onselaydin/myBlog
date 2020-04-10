using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myBlog.Controllers;
using myBlog.Data;
using myBlog.Interfaces;
using myBlog.Repositories;
using myBlog.Models;
using Xunit;

namespace myBlog.Tests
{
    public class AccountControllerTest
    {
   
        private AccountRepos repos;
        public static DbContextOptions<DataContext> dbContextOptions { get; }
        public static string connString = "User Id=postgres; Password=post123; Server=157.230.105.22; Port=5432;Database=blog; Integrated Security=true; Pooling=true;";
        static AccountControllerTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(connString)
                .Options;
        }
        public AccountControllerTest()
        {
            var context = new DataContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);
            repos = new AccountRepos(context);
            
        }

        [Fact]
        public async void Get_AccountById_Return_OkResult()
        {
            var accCont = new AccountController(repos);
            var usrId = 2;
            var okResult = await accCont.GetAccount(usrId);
            Assert.IsType<OkObjectResult>(okResult);

        }

        [Fact]
        public async void Get_Accounts_Return_OkResult()
        {
            var accCont = new AccountController(repos);
            var okResult = await accCont.GetAccounts();
            Assert.IsType<OkObjectResult>(okResult);

        }
        [Fact]
        public async void Get_Account_Return_NotFoundResult()
        {
            var accCont = new AccountController(repos);
            var usrId = 3;
            var data = await accCont.GetAccount(usrId);
            Assert.IsType<NotFoundObjectResult>(data);

        }

        [Fact]
        public async void Delete_Account_Return_OkResult()
        {
            var controller = new AccountController(repos);
            var postId = 2;
            var data = await controller.DeleteAccount(postId);
            Assert.IsType<OkResult>(data);
        }
    }
}
