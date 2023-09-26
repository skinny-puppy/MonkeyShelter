using AutoMapper;
using MonkeyShelter.Entities;
using MonkeyShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonkeyShelter.Common.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Register all model with Dtos here
            CreateMap<Entities.Monkey, Models.MonkeyDto>();
            CreateMap<Models.MonkeyDto, Entities.Monkey>();
            CreateMap<Models.MonkeyCreateDto, Entities.Monkey>();
            CreateMap<Models.MonkeyUpdateDto, Entities.Monkey>();
        }
    }
}