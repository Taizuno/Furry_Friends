using FurryFriends.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace FurryFriends.Models.Comment
{
    public class CommentListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
         public int PostId { get; set; }
         public DateTime DateTimeCreated { get; set; }
         public DateTime DateTimeUpdated { get; set; }
        public PostEntity RelatedPost { get; set; }
    }
}