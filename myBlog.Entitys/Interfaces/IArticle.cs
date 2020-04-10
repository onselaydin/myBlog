using myBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBlog.Interfaces
{
    public interface IArticle
    {
        Task<List<Article>> GetArticles();

        Task<Article> GetArticle(int? articleId);

        Task<int> AddArticle(Article article);

        Task<int> DeleteArticle(int? articleId);

        Task UpdateArticle(Article article);
    }
}