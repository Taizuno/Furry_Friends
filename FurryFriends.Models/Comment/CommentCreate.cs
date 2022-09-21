using FurryFriends.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace FurryFriends.Models.Comment
{
    public class CommentCreate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public DateTime DateTimeCreated { get; set; }

    }
}