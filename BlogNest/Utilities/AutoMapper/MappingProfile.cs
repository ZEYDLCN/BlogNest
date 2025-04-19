using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models.BlogNest.Models;

namespace BlogNest.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostDtoForUpdate, Post>(); 
            CreateMap<Post,PostDto>();
            CreateMap<PostDtoForCreate, Post>();    
        }
    }
}
