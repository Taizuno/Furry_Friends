using FurryFriends.Data;

namespace FurryFriends.Services.Post
{
    public class PostServices : IPostServices
    {
        private readonly ApplicationDbContext _DbContext;
        public PostServices(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }
    }
}