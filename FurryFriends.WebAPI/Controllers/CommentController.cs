using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FurryFriends.Services.Comment;
using FurryFriends.Models.Comment;
using FurryFriends.Services.Wrapper;

namespace FurryFriends.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentServices _service;
        public CommentController(ICommentServices service)
        {
            _service = service;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateComment([FromBody] CommentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createResult = await _service.CreateCommentAsync(model);
            if (createResult)
            {
                return Ok("Comment was created");
            }
            return BadRequest("Comment could not be made");
        }

        [HttpGet("{commentId:int}")]
        public async Task<IActionResult> GetCommentbyID([FromRoute] int commentID)
        {
            var getResult = await _service.GetCommentbyIDAsync(commentID);

            return getResult is not null ? Ok(new Response<CommentListItem>(getResult)) : NotFound();
        }

        [HttpGet]

        public async Task<IActionResult> GetCommentsbyUserName([FromQuery] string Username)
        {
            var getResult = await _service.GetCommentsbyUserNameAsync(Username);

            return Ok(new Response<IEnumerable<CommentListItem>>(getResult));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCommentByID([FromBody] CommentUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.UpdateCommentAsync(request) ? Ok(new Response<CommentUpdate>(request)) : BadRequest(new Response<CommentUpdate>(request));
        }

        [HttpDelete("{commentId:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int commentId)
        {
            return await _service.DeleteCommentAsync(commentId) ? Ok($"The comment (ID:{commentId}) has been deleted.") : BadRequest($"Comment (ID:{commentId}) could not be deleted.");
        }
    }
}