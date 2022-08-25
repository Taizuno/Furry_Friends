using System.ComponentModel.DataAnnotations;

namespace FurryFriends.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PetType { get; set; }
        public string Breed { get; set; }
        public string Bio { get; set; }
        public string Size { get; set; }
        public string City { get; set; }
    }
}