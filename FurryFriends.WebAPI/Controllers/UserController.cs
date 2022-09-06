using Microsoft.AspNetCore.Mvc;
using FurryFriends.Services.User;
using FurryFriends.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using FurryFriends.Models.User;
using FurryFriends.Services.Wrapper;

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

    [Authorize]
    [HttpGet("ByLocation")]

    public async Task<IActionResult> ViewProfileByLocation([FromBody] int CityID)
    {
        var petProfile = await _userService.GetProfileByLocation(CityID);

        if (petProfile is null)
        {
            return NotFound();
        }
        return Ok(petProfile);
    }

    [Authorize]
    [HttpGet("AnimalType")]
    
        public async Task<IActionResult> ViewProfileByAnimalType([FromBody] int PetType)
        {
            var petProfile = await _userService.GetProfileByAnimalType(PetType);

            if (petProfile is null)
            {
                return NotFound();
            }
            return Ok(petProfile);
        }

    [Authorize]
    [HttpGet("AnimalType")]

        public async Task<IActionResult> ViewProfileBreed([FromBody] int BreedId)
        {
            var petProfile = await _userService.GetProfileByBreed(BreedId);

            if (petProfile is null)
            {
                return NotFound();
            }
            return Ok(petProfile);
        }

    [Authorize]
    [HttpGet("BySize")]

        public async Task<IActionResult> ViewProfileBySize([FromBody] int Size)
        {
            var petProfile = await _userService.GetProfileByBreed(Size);

            if (petProfile is null)
            {
                return NotFound();
            }
            return Ok(petProfile);
        } 
    [Authorize]
    [HttpGet("AgeRange")]

        public async Task<IActionResult> ViewProfileByAge([FromBody] int UpperAge, int LowerAge)
        {
            var petProfile = await _userService.GetProfileByAgeRange(UpperAge, LowerAge);

            if (petProfile is null)
            {
                return NotFound();
            }
            return Ok(petProfile);
        } 

    [HttpPut]
    public async Task<IActionResult> EditProfile([FromBody] ProfileUpdate request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return await _userService.UpdateAProfile(request) ? Ok(new Response<ProfileUpdate>(request)) : BadRequest(new Response<ProfileUpdate>(request));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser ([FromRoute] int Id)
    {
        return await _userService.DeleteAUser(Id) ? Ok($"Post with the id:{Id} was deleted successfully.") : BadRequest($"Post with {Id} could not be deleted.");
    }
    }
    }
    
