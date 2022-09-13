using FurryFriends.Data;
using FurryFriends.Data.Entities;
using FurryFriends.Models.Comment;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FurryFriends.Services.Wrapper;
using Microsoft.AspNetCore.Http;
namespace FurryFriends.Services.Comment
{
    public class CommentServices : ICommentServices
    {
        private readonly int _postID;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _DbContext;
        public CommentServices(ApplicationDbContext DbContext, IMapper mapper)
        {
            _DbContext = DbContext;
            _mapper = mapper;
        }
        public async Task<bool> CreateCommentAsync(CommentCreate model)
        {
            if (await GetCommentByIDAsync(model.Id) != null)
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
        public async Task<CommentListItem> GetCommentByIDAsync(int commentId)
        {
            var comment = await _DbContext.Comment.FirstOrDefaultAsync(e => e.Id == commentId);

            return _mapper.Map<CommentListItem>(comment);
            
        }
        public async Task<IEnumerable<CommentListItem>> GetCommentsByUserNameAsync(PaginationFilter _filter, HttpContext httpContext, string Username)
        {
            var comments = await _DbContext.Comment
                .Select(entity => _mapper.Map<CommentListItem>(entity));

            var pMetadata = new PaginationMetaData(comments.Count(),
            _filter.CurrentPage, _filter.PageSize);
            httpContext.Response.Headers.Add("Pagination", JsonSerializer.Serialize(pMetadata));

            var list = await comments.Skip((_filter.CurrentPage -1) * _filter.PageSize)
                .Take(_filter.PageSize)
                .ToListAsync();
        }
        
        public async Task<bool> UpdateCommentAsync(CommentUpdate request)
        {
            var commentUserCheck = await _DbContext.Comment.AnyAsync(comment => comment.Id == request.Id && comment.PostId == _postID);

            if (!commentUserCheck)
            {
                return false;
            }

            var updatedComment = _mapper.Map<CommentUpdate, CommentEntity>(request, opt => opt.AfterMap((src, dest) => dest.PostId = _postID));
            _DbContext.Entry(updatedComment).State = EntityState.Modified;
            _DbContext.Entry(updatedComment).Property(e => e.DateTimeCreated).IsModified = false;
            var numberOfChanges = await _DbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var commentDelete = await _DbContext.Comment.FindAsync(commentId);

            _DbContext.Comment.Remove(commentDelete);
            return await _DbContext.SaveChangesAsync() == 1;
        }
    }
}