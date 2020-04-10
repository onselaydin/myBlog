using System;
using System.ComponentModel.DataAnnotations;
using myBlog.Interfaces;

namespace myBlog.Models
{
    public class Message
    {
        [Key]
        public int Message_Id { get; set; }
        public string Msg { get; set; }
        public DateTime MessageDate { get; set; }
        public int Viewed { get; set; }
        public Account SenderId { get; set; }
        public Account ReceiverId { get; set; }


    }
}