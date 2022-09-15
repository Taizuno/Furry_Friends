using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurryFriends.Models.Post
{
    public class PostCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be atleast {1} characters long")]
        [MaxLength(250, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string Text { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeUpdated { get; set; }

        public int OwnerId { get; set; }

    }
}