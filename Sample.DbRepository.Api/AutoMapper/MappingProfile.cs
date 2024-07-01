using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Sample.DbRepository.Api.Models;
using ManagementModels = Sample.DbRepository.Domain.Management.Models;
using SearchModels = Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchModels.Genre, Genre>()
                    .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForAllMembers(o => o.Condition((src, dest, value) => value != null));

            CreateMap<SearchModels.Artist, Artist>()
                    .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForAllMembers(o => o.Condition((src, dest, value) => value != null));
        }
    }
}
