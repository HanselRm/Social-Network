using AutoMapper;
using SocialNet.Core.Application.ViewModels.Users;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        { 
            CreateMap<User, SaveUserViewModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.FriendshipsAsUser1, opt => opt.Ignore())
                .ForMember(dest => dest.FriendshipsAsUser2, opt => opt.Ignore())
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.CreateBy, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());


        }
    }
}
