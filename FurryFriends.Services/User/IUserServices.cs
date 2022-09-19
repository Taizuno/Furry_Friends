using FurryFriends.Models.Users;
using FurryFriends.Models.User;
using FurryFriends.Data.Entities;

namespace FurryFriends.Services.User
{
    public interface IUserServices
    {
        Task<bool> RegisterUserAsync(UserCreate model);
        Task<bool> CreatePetProfileAsync(CreatePetProfile model);
        Task<List<PetProfile>> GetAllProfiles();
        List<PetProfile> GetProfileByLocation(int CityID);
        List<PetProfile> GetProfileByAnimalType(int PetType);
        List<PetProfile> GetProfileByBreed(int BreedId);
        List<PetProfile> GetProfileBySize(int Size);
        List<ProfileEntity> GetProfileByAgeRange(int UpperAge, int LowerAge);
        Task<bool> UpdateAProfile(ProfileUpdate request);
        Task<bool> DeleteAUser(int Id);
    }
}