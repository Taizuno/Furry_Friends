using FurryFriends.Models.Post;

namespace FurryFriends.Services.Post
{
    public interface IPostServices
    {
        Task<bool> CreatePostAsync(PostCreate model);
        Task<PostListItem> GetPostByIdAsync(int postId);
        Task<IEnumerable<PostListItem>> GetAllPostsAsync();
        Task<bool> UpdatePostAsync(PostUpdate request);
        Task<bool> DeleteAPostAsync(int postId);
    }
}