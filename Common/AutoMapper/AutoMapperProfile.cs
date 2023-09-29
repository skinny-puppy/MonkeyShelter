using AutoMapper;

namespace MonkeyShelter.Common.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Monkey, Models.MonkeyDto>();
            CreateMap<Models.MonkeyDto, Entities.Monkey>();
            CreateMap<Models.MonkeyCreateDto, Entities.Monkey>();
            CreateMap<Models.MonkeyUpdateDto, Entities.Monkey>();
        }
    }
}