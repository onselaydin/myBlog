using myBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBlog.Interfaces
{
    public interface IArticleType
    {
        //Task<List<ArticleType>> GetArticle();

        Task<List<ArticleType>> GetArticleTypes();

        Task<Account> GetArticleType(int? articletypeId);

        Task<int> AddArticleType(ArticleType articletype);

        Task<int> DeleteArticleType(int? articletypeId);

        Task UpdateArticleType(Account articletype);
    }
}