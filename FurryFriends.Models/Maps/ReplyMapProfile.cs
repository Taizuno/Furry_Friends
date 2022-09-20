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
                .ForMember(reply => reply.DateTimeCreated, opt => opt.MapFrom(src => DateTime.Now));


            CreateMap<ReplyUpdate, ReplyEntity>()
                .ForMember(reply => reply.DateTimeUpdated, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}