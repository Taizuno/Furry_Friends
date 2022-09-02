namespace FurryFriends.Models.Reply
{
    public class ReplyListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string UserName { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeUpdated { get; set; }

        public int CommentId { get; set; }
    }
}