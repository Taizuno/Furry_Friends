using System.Security.Claims;
using AutoMapper;
using FurryFriends.Data;
using FurryFriends.Data.Entities;
using FurryFriends.Models.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FurryFriends.Services.Post
{
    public class PostServices : IPostServices
    {
        private readonly int _userId;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _DbContext;
        public PostServices(IMapper mapper, ApplicationDbContext DbContext, IHttpContextAccessor httpContextAccessor)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            _mapper = mapper;
            _DbContext = DbContext;
        }

        public async Task<bool> CreatePostAsync(PostCreate model)
        {
            var userId = User.Identity.Id;
            var author = _DbContext.User.SingleOrDefault(x => x.Id == userId);

            var entity = new PostEntity
            {

                Text = model.Text,
                UserName = model.UserName,
                DateTimeCreated = DateTime.Now,
                OwnerId = author

            };
            _DbContext.Post.Add(entity);
            var numberOfChanges = await _DbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<PostListItem> GetPostByIdAsync(int postId)
        {
            var postToUser = await _DbContext.Post
                .FirstOrDefaultAsync(e => e.Id == postId && e.OwnerId == _userId);

            return postToUser is null ? null : new PostListItem
            {
                Id = postToUser.Id,
                Text = postToUser.Text,
                UserName = postToUser.UserName,
                DateTimeCreated = postToUser.DateTimeCreated,
                DateTimeUpdated = postToUser.DateTimeUpdated,
                OwnerId = postToUser.OwnerId
            };
        }

        public async Task<IEnumerable<PostListItem>> GetAllPostsAsync()
        {
            var posts = await _DbContext.Post
                    .Select(entity => _mapper.Map<PostListItem>(posts)
                    {
                Id = entity.Id,
                        Text = entity.Text,
                        UserName = entity.UserName,
                        DateTimeCreated = entity.DateTimeCreated,
                        OwnerId = entity.OwnerId
                    })
                    .ToListAsync();

            return posts;

        }

        public async Task<bool> UpdatePostAsync(PostUpdate request)
        {
            var postEntity = await _DbContext.Post.FindAsync(request.Id);

            postEntity.Id = request.Id;
            postEntity.Text = request.Text;
            postEntity.UserName = request.UserName;
            postEntity.DateTimeUpdated = DateTime.Now;

            var numberOfChanges = await _DbContext.SaveChangesAsync();

            return numberOfChanges == 1;

        }

        public async Task<bool> DeleteAPostAsync(int postId)
        {
            var postToDelete = await _DbContext.Post.FindAsync(postId);

            _DbContext.Post.Remove(postToDelete);
            return await _DbContext.SaveChangesAsync() == 1;
        }


    }
}