using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FurryFriends.Models.User
{
    public class ProfileUpdate
    {
    public int Id { get; set; }
    public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public string Bio { get; set; }

        public virtual int Size
        {
            get 
            {
                return (int)this.PetSize;
            }
            set
            {
                Size = (int)(PetSizes)value;
            }
        }

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

    [EnumDataType(typeof(PetSizes))]
    public PetSizes PetSize { get; set; }
    }

    }
    