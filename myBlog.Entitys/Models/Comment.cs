using System;
using System.ComponentModel.DataAnnotations;
using myBlog.Interfaces;

namespace myBlog.Models
{
    public class Comment
    {
        [Key]
        public int Comment_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }
        public Article ArticleId { get; set; }
        public Account WriterId { get; set; }
        
    }
}