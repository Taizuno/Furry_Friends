namespace FurryFriends.Models.Post
{
    public class PostUpdate
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string UserName { get; set; }

        public DateTime DateTimeUpdated { get; set; }


    }
}