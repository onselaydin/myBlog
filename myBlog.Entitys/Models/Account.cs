using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myBlog.Models
{
    public class Account
    {
        [Key]
        public int User_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Sure_Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public string Nick { get; set; }
        public int Picture_Id { get; set; }
        public bool Is_Writer { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Message> Messages { get; set; }

        
        
    }
}