using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using myBlog.Interfaces;

namespace myBlog.Models
{
    public class ArticleType
    {
        [Key]
        public int ArticleType_Id { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}