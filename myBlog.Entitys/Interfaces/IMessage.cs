using myBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBlog.Interfaces
{
    public interface IMessage
    {
          Task<List<Message>> GetMessages();

        Task<Message> GetMessage(int? messageId);

        Task<int> AddMessage(Message message);

        Task<int> DeleteMessage(int? messageId);

        Task UpdateMessage(Message message);
    }
}