using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurryFriends.Models.User
{
    public class PetProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }       
        public string Size { get; set; }
        public string PetType { get; set; }     
        public string BreedId { get; set; }
        public string CityID { get; set; }

    }

    }
