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

         [Required]
    public virtual int CityID
    {
        get
        {
            return (int)this.CityName;
        }
        set
        {
            CityName = (CityNames)value;
        }
    }
    [EnumDataType(typeof(CityNames))]
    public CityNames CityName{ get; set;}

    [EnumDataType(typeof(PetTypes))]
    public PetTypes PetTypeEnum { get; set; }
    }

   
      
    public enum CityNames
    {
        Indianapolis = 0,
        Mooresville = 1,
        Beach_Grove = 2,
        Carmel = 3,
        Greenwood = 4,
        Planefield = 5,
        Noblesville = 6,
        Brownsburg = 7,
        Fishers = 8,
        Speedway = 9,
        Zionsvile = 10
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