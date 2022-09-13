using FurryFriends.Models.Users;
using FurryFriends.Models.User;

namespace FurryFriends.Services.User
{
    public interface IUserServices
    {
        Task<bool> RegisterUserAsync(UserCreate model);
        Task<bool> CreatePetProfileAsync(PetProfile model);
        Task<List<PetProfile>> GetAllProfiles();
        Task<PetProfile> GetProfileByLocation(int CityID);
        Task<PetProfile> GetProfileByAnimalType(int PetType);
        Task<PetProfile> GetProfileByBreed(int BreedId);
        Task<PetProfile> GetProfileBySize(int Size);
        Task<List<PetProfile>> GetProfileByAgeRange(int UpperAge, int LowerAge);
        Task<bool> UpdateAProfile(ProfileUpdate request);
        Task<bool> DeleteAUser(int Id);
    }
}