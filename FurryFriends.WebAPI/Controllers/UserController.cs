using Microsoft.AspNetCore.Mvc;
using FurryFriends.Services.User;
using FurryFriends.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using FurryFriends.Models.User;

namespace FurryFriends.WebAPI.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userService)
        {
            _userService = userService;
        }
    

    [HttpPost("Register")]  
    public async Task<IActionResult> RegisterUser ([FromBody] UserCreate model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var registerResult = await _userService.RegisterUserAsync(model);
        if (registerResult)
        {
            return Ok("User was registered.");
        }
        
        return BadRequest("User could not be registered.");
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateProfile ([FromBody] PetProfile model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createResult = await _userService.CreatePetProfileAsync(model);
        if (createResult)
        {
            return Ok("Profile was created.");
        }

        return BadRequest("User could not be registered.");

    }

    [HttpGet("AllProfiles")]

    public async Task<IActionResult> ViewAllProfiles()
    {
        var petProfiles = await _userService.GetAllProfiles();

        if (petProfiles is null)
        {
            return NotFound();
        }
        return Ok(petProfiles);
    }
    }
}