using Microsoft.EntityFrameworkCore;
using myBlog.Models;

namespace myBlog.Data
{
    public class DataContext: DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options): base(options){ }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Article> Articles {get;set;}
        public DbSet<ArticleType> ArticleTypes {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<Comment> Comments {get;set;}
        public DbSet<Message> Messages {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasMany(p=>p.Pictures).WithOne(a=>a.AddedUserId);
            modelBuilder.Entity<Account>().HasMany(m=>m.Messages).WithOne(a=>a.SenderId);
            //modelBuilder.Entity<Account>().HasMany(m=>m.Messages).WithOne(a=>a.ReceiverId);
            

        }
    }
}