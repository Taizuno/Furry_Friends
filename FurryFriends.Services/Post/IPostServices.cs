using FurryFriends.Models.Post;
using FurryFriends.Services.Wrapper;
using Microsoft.AspNetCore.Http;

namespace FurryFriends.Services.Post
{
    public interface IPostServices
    {
        Task<bool> CreatePostAsync(PostCreate model);
        Task<PostListItem> GetPostByIdAsync(int postId);
        Task<IEnumerable<PostListItem>> GetAllPostsAsync(PaginationFilter _filter, HttpContext httpContext);
        Task<bool> UpdatePostAsync(PostUpdate request);
        Task<bool> DeleteAPostAsync(int postId);
    }
}