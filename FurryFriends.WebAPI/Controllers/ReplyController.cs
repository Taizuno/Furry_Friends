using FurryFriends.Models.Reply;
using FurryFriends.Services.Reply;
using FurryFriends.Services.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace FurryFriends.WebAPI.Controllers
{
    public class ReplyController : ControllerBase
    {
        private readonly IReplyServices _replyServices;
        public ReplyController(IReplyServices replyServices)
        {
            _replyServices = replyServices;
        }
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ReplyCreate>), 200)]
        public async Task<IActionResult> CreateReply([FromBody] ReplyCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _replyServices.CreateReplyAsync(request))
                return Ok("Reply created successfully.");

            return BadRequest("Reply could not be created");

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReplyListItem>), 200)]

        public async Task<IActionResult> GetAllReplies([FromQuery] PaginationFilter filter)
        {
            var replies = await _replyServices.GetAllReplyAsync(filter, HttpContext);
            return Ok(new Response<IEnumerable<ReplyListItem>>(replies));

        }

        [HttpGet("{replyId:int}")]
        [ProducesResponseType(typeof(IEnumerable<ReplyListItem>), 200)]
        public async Task<IActionResult> GetReplyById([FromRoute] int replyId)
        {
            var replyById = await _replyServices.GetReplyByIdAsync(replyId);

            return replyById is not null ? Ok(new Response<ReplyListItem>(replyById)) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReplyById([FromBody] ReplyUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _replyServices.UpdateReplyAsync(request) ? Ok(new Response<ReplyUpdate>(request)) : BadRequest(new Response<ReplyUpdate>(request));
        }


        [HttpDelete("{replyId:int}")]
        public async Task<IActionResult> DeleteReply([FromRoute] int replyId)
        {
            return await _replyServices.DeleteAReplyAsync(replyId) ? Ok($"The Reply with the id:{replyId} was deleted successfully.") : BadRequest($"The Reply with the id:{replyId} could not be deleted.");
        }
    }
}