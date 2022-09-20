using Microsoft.AspNetCore.Mvc;
using FurryFriends.Services.User;
using FurryFriends.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using FurryFriends.Models.User;
using FurryFriends.Services.Wrapper;

namespace FurryFriends.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userService)
        {
            _userService = userService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromForm] UserCreate model)
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
        public async Task<IActionResult> CreateProfile([FromForm] CreatePetProfile model)
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

        [HttpGet("ByLocation")]

        public async Task<IActionResult> ViewProfileByLocation([FromForm] int CityID)
        {
            var petProfile = _userService.GetProfileByLocation(CityID);

            if (petProfile is null)
            {
                return NotFound();
            }
            return Ok(petProfile);
        }

        [HttpGet("ByAnimalType")]

        public async Task<IActionResult> ViewProfileByAnimalType([FromForm] int PetType)
        {
            var petProfile = _userService.GetProfileByAnimalType(PetType);

            if (petProfile is null)
            {
                return NotFound();
            }
            return Ok(petProfile);
        }

        [HttpGet("ByBreed")]

        public async Task<IActionResult> ViewProfileBreed([FromForm] int BreedId)
        {
            var petProfile = _userService.GetProfileByBreed(BreedId);

            if (petProfile is null)
            {
                return NotFound();
            }
            return Ok(petProfile);
        }

        [HttpGet("BySize")]

        public async Task<IActionResult> ViewProfileBySize([FromForm] int Size)
        {
            var petProfile = _userService.GetProfileBySize(Size);

            if (petProfile is null)
            {
                return NotFound();
            }
            return Ok(petProfile);
        }


        [HttpGet("AgeRange")]

        public IActionResult ViewProfileByAge([FromForm] int UpperAge, int LowerAge)
        {
            var petProfile = _userService.GetProfileByAgeRange(UpperAge, LowerAge);

            if (petProfile is null)
            {
                return NotFound();
            }
            return Ok(petProfile);
        }

        [HttpPut("Modify")]
        public async Task<IActionResult> EditProfile([FromForm] ProfileUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _userService.UpdateAProfile(request) ? Ok(new Response<ProfileUpdate>(request)) : BadRequest(new Response<ProfileUpdate>(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser([FromForm] int Id)
        {
            return await _userService.DeleteAUser(Id) ? Ok($"User with the id:{Id} was deleted successfully.") : BadRequest($"User with id:{Id} could not be deleted.");
        }
    }
}

