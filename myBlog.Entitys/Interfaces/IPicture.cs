using myBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBlog.Interfaces
{
    public interface IPicture
    {
        Task<List<Picture>> GetPictures();

        Task<Picture> GetPicture(int? pictureId);

        Task<int> AddPicture(Picture picture);

        Task<int> DeletePicture(int? pictureId);

        Task UpdatePicture(Picture picture);
    }
}