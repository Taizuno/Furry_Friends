using System.Threading.Tasks;
using FurryFriends.Models.Comment;
using FurryFriends.Data.Entities;
using Microsoft.AspNetCore.Http;
using FurryFriends.Services.Wrapper;
namespace FurryFriends.Services.Comment
{
    public interface ICommentServices
    {
         Task<bool> CreateCommentAsync(CommentCreate model);
         Task<CommentListItem> GetCommentbyIDAsync(int commentID);
         Task<List<CommentListItem>> GetCommentsbyUserNameAsync(string Username);
         Task<bool> UpdateCommentAsync(CommentUpdate request);
         Task<bool> DeleteCommentAsync(int commentID);
    }
}