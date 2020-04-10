using System;
using System.ComponentModel.DataAnnotations;
using myBlog.Interfaces;

namespace myBlog.Models
{
    public class Article
    {
        [Key]
        public int Article_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public bool isActive { get; set; }
        public Picture CoverPictureId { get; set; }
        public Category CategoryId { get; set; }
        public ArticleType ArticleTypeId { get; set; }
        public Account WriterId { get; set; }

    }
}