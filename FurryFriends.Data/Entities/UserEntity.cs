using System.ComponentModel.DataAnnotations;

namespace FurryFriends.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual int PetType
        {
            get
            {
                return (int)this.PetTypeEnum;
            }
            set
            {
                PetType = (int)(PetTypes)value;
            }
        }
        public string Breed { get; set; }
        public string Bio { get; set; }
        public string Size { get; set; }
        public string City { get; set; }

        [EnumDataType(typeof(PetTypes))]
        public PetTypes PetTypeEnum { get; set; }
    }




    public enum PetTypes
    {
        Dog = 0,
        Cat = 1,
        Hampster = 2,
        Chicken = 3,
        Lobster = 4,
        Fish = 5,
        Bird = 6,
        Other = 7
    }

}