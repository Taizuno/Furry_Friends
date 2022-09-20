using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurryFriends.Data.Entities
{
    public class ReplyEntity
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        //[ForeignKey("Comment")]
        public int CommentId { get; set; }
        //public CommentEntity Comment { get; set; }
    }
}