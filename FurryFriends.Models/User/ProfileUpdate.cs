using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FurryFriends.Data.Entities;

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
    public int Size { get; set; }
    public int PetType { get; set; }     
    public int BreedId { get; set; }
    public int CityID { get; set; }
    }
    }
    