using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurryFriends.Data.Entities;

namespace FurryFriends.Models.User
{
    public class CreatePetProfile
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }       
        public PetSizes Size { get; set; }
        public PetTypes PetType { get; set; }     
        public Breeds BreedId { get; set; }
        public CityNames CityID { get; set; }
    }
}