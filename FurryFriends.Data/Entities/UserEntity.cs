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
        [Required]
        public virtual int BreedId 
        {
            get
            {
                return (int)this.Breed;
            }
            set
            {
                Breed = (Breeds)value;
            }
        }
        [EnumDataType(typeof(Breeds))]
        public Breeds Breed { get; set; }
        public enum Breeds {
            GoldenRetriever = 0,
            LabradorRetriever = 1,
            FrenchBullDog = 2,
            Beagle = 3,
            GermanShepherd = 4,
            Poodle = 5,
            Bulldog = 6,
            Pomeranian = 7,
            PitbullTerrier = 8,
            Husky = 9,
            Chihuahua = 10,
            Corgi = 11,
            MixedBreed = 12,
            AlaskanMalamute = 13,
            BorderCollie = 14,
            JackRussellTerrier = 15, 
            BassetHound = 16,
            SharPei = 17,
            YorkshireTerrier = 18,
            Rottweiler = 19,
            SaintBernard = 20, 
            Newfoundland = 21, 
            Greyhound = 22, 
            CockerSpaniel = 23,
            Daschund = 24,
            Other = 25

        }
        public string Bio { get; set; }
        public string Size { get; set; }
        public string City { get; set; }
    }
}