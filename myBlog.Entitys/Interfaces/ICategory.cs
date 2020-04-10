using myBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBlog.Interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetCategorys();

        Task<Category> GetCategory(int? categoryId);

        Task<int> AddCategory(Category category);

        Task<int> DeleteCategory(int? categoryId);

        Task UpdateCategory(Category category);
    }
}