using System;
using System.ComponentModel.DataAnnotations;
using myBlog.Interfaces;

namespace myBlog.Models
{
    public class Picture
    {
        [Key]
        public int Picture_Id { get; set; }
        public string Name {get;set;}
        public string SmallPicture { get; set; }
        public string MediumPicture { get; set; }
        public string LargePicture { get; set; }
        public DateTime CreateDate { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public Account  AddedUserId { get; set; }

    }
}