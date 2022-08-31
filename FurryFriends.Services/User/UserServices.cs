using FurryFriends.Data;
using FurryFriends.Models.Users;
using FurryFriends.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FurryFriends.Models.User;

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
            };

            _DbContext.User.Add(entity);
            var numberOfChanges = await _DbContext.SaveChangesAsync();
            
            return numberOfChanges == 1; 


        }
    }
}