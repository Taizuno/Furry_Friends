using FurryFriends.Data;
using FurryFriends.Models.Users;
using FurryFriends.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FurryFriends.Models.User;
using System.Linq;

namespace FurryFriends.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _DbContext;
        public UserServices(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<bool> RegisterUserAsync (UserCreate model)
        {
            if (await GetUserByEmailAsync(model.Email) != null || await GetUserByUsernameAsync (model.Username) != null)
            return false; 

            var entity = new UserEntity
            {
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var passwordHasher = new PasswordHasher<UserEntity>();
            entity.Password = passwordHasher.HashPassword(entity, model.Password);

            _DbContext.User.Add(entity);
            var numberOfChanges = await _DbContext.SaveChangesAsync();
            
            return numberOfChanges == 1; 

        }
        
        private async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _DbContext.User.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }

        private async Task<UserEntity> GetUserByUsernameAsync(string username)
        {
            return await _DbContext.User.FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());
        } 

        public async Task<bool> CreatePetProfileAsync (PetProfile model)
        {
            if (await GetUserByEmailAsync(model.Email) != null || await GetUserByUsernameAsync (model.Username) != null)
            return false; 
            var entity = new UserEntity
            {
                Name = model.Name,
                Age = model.Age,
                PetType = model.PetType,
                BreedId = model.BreedId,
                CityID = model.CityID,
                Bio = model.Bio,
            };

            _DbContext.User.Add(entity);
            var numberOfChanges = await _DbContext.SaveChangesAsync();
            
            return numberOfChanges == 1; 


        }
        public async Task<PetProfile> GetAllProfiles()
        {
            var entity = await _DbContext.User.FirstOrDefaultAsync();
            var petProfile = new PetProfile
            {
                Name = entity.Name,
                Age = entity.Age,
                PetType = entity.PetType,
                BreedId = entity.BreedId,
                CityID = entity.CityID,
                Bio = entity.Bio,
            };
            return petProfile;
        }    
        
        public async Task<PetProfile> GetProfileByLocation(int CityID)
        {
            var entity = await _DbContext.User.FindAsync(CityID);
            if (entity is null)
            {
                return null;
            }
            var petProfile = new PetProfile
            {
                Name = entity.Name,
                Age = entity.Age,
                PetType = entity.PetType,
                BreedId = entity.BreedId,
                CityID = entity.CityID,
                Bio = entity.Bio,
            };
            return petProfile;
        }
        }
        }
