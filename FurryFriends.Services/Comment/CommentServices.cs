using FurryFriends.Data;
using FurryFriends.Data.Entities;
using FurryFriends.Models.Comment;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace FurryFriends.Services.Comment
{
    public class CommentServices : ICommentServices
    {
        private readonly ApplicationDbContext _DbContext;
        public CommentServices(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<bool> CreateCommentAsync(CommentCreate model)
        {
            if (await GetCommentByUserNameAsync(model.UserName) != null)
                return false;
            var entity = new CommentEntity
            {
                Id = model.Id,
                Text = model.Text,
                UserName = model.UserName,
                DateTimeCreated = DateTime.Now,
                PostId = model.PostId,
                RelatedPost = model.RelatedPost
            };

            _DbContext.Comment.Add(entity);
            var numberOfChanges = await _DbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        private async Task<CommentEntity> GetCommentByUserNameAsync(string Username)
        {
            var entity = await _DbContext.Comment.FirstOrDefaultAsync(e => e.UserName == Username);

            return entity is null ? null : 
            
        }
        
    }
}