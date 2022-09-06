using System.Threading.Tasks;
using FurryFriends.Models.Comment;
using FurryFriends.Data.Entities;
namespace FurryFriends.Services.Comment
{
    public interface ICommentServices
    {
         Task<bool> CreateCommentAsync(CommentCreate model);
         Task<CommentEntity> GetCommentbyUserNameAsync(string UserName);
    }
}