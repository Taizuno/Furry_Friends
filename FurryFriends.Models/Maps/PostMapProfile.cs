using AutoMapper;
using FurryFriends.Data.Entities;
using FurryFriends.Models.Post;

namespace FurryFriends.Models.Maps
{
    public class PostMapProfile : Profile
    {
        public PostMapProfile()
        {

            CreateMap<PostEntity, PostListItem>();



            CreateMap<PostCreate, PostEntity>()
                .ForMember(post => post.DateTimeCreated, opt => opt.MapFrom(src => DateTime.Now));


            CreateMap<PostUpdate, PostEntity>()
                .ForMember(post => post.DateTimeUpdated, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}