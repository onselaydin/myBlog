using CloudinaryDotNet;
using myBlog.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace myBlog.Tests
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {

        }
        public void Seed(DataContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Accounts.AddRange(
                new Models.Account() { Name="Önsel", Sure_Name ="AYDIN",Email="onselaydin@gmail.com",CreateDate=DateTime.Now,Nick="oncell",Picture_Id=0,Is_Writer=true,PasswordHash="1234",PasswordSalt="1234"},
                new Models.Account() { Name = "Yağmur", Sure_Name = "AYDIN", Email = "yagmuraydin08@gmail.com", CreateDate = DateTime.Now, Nick = "rain", Picture_Id = 0, Is_Writer = true, PasswordHash = "4321", PasswordSalt = "4321" }
            );
            context.SaveChanges();
        }
    }
}
