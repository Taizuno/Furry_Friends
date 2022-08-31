using FurryFriends.Models.Post;
using FurryFriends.Services.Post;
using FurryFriends.Services.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace FurryFriends.WebAPI.Controllers
{
    public class PostController : ControllerBase
    {
        private readonly IPostServices _postServices;
        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<PostCreate>), 200)]
        public async Task<IActionResult> CreatePost([FromBody] PostCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _postServices.CreatePostAsync(request))
                return Ok("Post created successfully.");

            return BadRequest("Post could not be created");

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostListItem>), 200)]

        public async Task<IActionResult> GetAllPosts([FromQuery] PaginationFilter filter)
        {
            var posts = await _postServices.GetAllPostsAsync(filter, HttpContext);
            return Ok(new Response<IEnumerable<PostListItem>>(posts));

        }

        [HttpGet("{postId:int}")]
        [ProducesResponseType(typeof(IEnumerable<PostListItem>), 200)]
        public async Task<IActionResult> GetPostById([FromRoute] int postId)
        {
            var detail = await _postServices.GetPostByIdAsync(postId);

            return detail is not null ? Ok(new Response<PostListItem>(detail)) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostById([FromBody] PostUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _postServices.UpdatePostAsync(request) ? Ok("Post Updated successfully.") : BadRequest("Post could not be updated. ");
        }


        [HttpDelete("{postId:int}")]
        public async Task<IActionResult> DeletePost([FromRoute] int postId)
        {
            return await _postServices.DeleteAPostAsync(postId) ? Ok($"Post with the id:{postId} was deleted successfully.") : BadRequest($"Post with the id:{postId} could not be deleted.");
        }
    }
}