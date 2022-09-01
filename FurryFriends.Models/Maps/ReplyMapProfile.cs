using AutoMapper;
using FurryFriends.Data.Entities;
using FurryFriends.Models.Reply;

namespace FurryFriends.Models.Maps
{
    public class ReplyMapProfile : Profile
    {
        public ReplyMapProfile()
        {

            CreateMap<ReplyEntity, ReplyListItem>();



            CreateMap<ReplyCreate, ReplyEntity>()
                .ForMember(post => post.DateTimeCreated, opt => opt.MapFrom(src => DateTimeOffset.Now));


            CreateMap<ReplyUpdate, ReplyEntity>()
                .ForMember(post => post.DateTimeUpdated, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}