using FurryFriends.Data;

namespace FurryFriends.Services.Comment
{
    public class CommentServices : ICommentServices
    {
        private readonly ApplicationDbContext _DbContext;
        public CommentServices(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }
    }
}