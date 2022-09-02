using FurryFriends.Models.Users;
using FurryFriends.Models.User;

namespace FurryFriends.Services.User
{
    public interface IUserServices
    {
        Task<bool> RegisterUserAsync(UserCreate model);
        Task<bool> CreatePetProfileAsync(PetProfile model);
        Task<PetProfile> GetAllProfiles();
    }
}