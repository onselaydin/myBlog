using myBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBlog.Interfaces
{
    public interface IComment
    {
        Task<List<Comment>> GetComments();

        Task<Comment> GetComment(int? commentId);

        Task<int> AddComment(Comment comment);

        Task<int> DeleteComment(int? commentId);

        Task UpdateComment(Comment comment);
    }
}