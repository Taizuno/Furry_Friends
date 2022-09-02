using FurryFriends.Models.Reply;
using FurryFriends.Services.Wrapper;
using Microsoft.AspNetCore.Http;

namespace FurryFriends.Services.Reply
{
    public interface IReplyServices
    {
        Task<bool> CreateReplyAsync(ReplyCreate model);
        Task<ReplyListItem> GetReplyByIdAsync(int replyId);
        Task<IEnumerable<ReplyListItem>> GetAllReplyAsync(PaginationFilter _filter, HttpContext httpContext);
        Task<bool> UpdateReplyAsync(ReplyUpdate request);
        Task<bool> DeleteAReplyAsync(int replyId);
    }
}