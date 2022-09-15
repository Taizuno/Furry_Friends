using AutoMapper;
using FurryFriends.Data.Entities;
using FurryFriends.Models.Comment;
using FurryFriends.Models.Post;

namespace FurryFriends.Models.Maps
{
    public class CommentMapProfile : Profile
    {
        public CommentMapProfile()
        {

            CreateMap<CommentEntity, CommentListItem>();



            CreateMap<CommentCreate, CommentEntity>()
                .ForMember(post => post.DateTimeCreated, opt => opt.MapFrom(src => DateTimeOffset.Now));


            CreateMap<CommentUpdate, CommentEntity>();

        }
    }
}