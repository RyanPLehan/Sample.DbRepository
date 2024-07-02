using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Sample.DbRepository.Api.Models;
using AggregationModels = Sample.DbRepository.Domain.Aggregation.Models;
using ManageModels = Sample.DbRepository.Domain.Management.Models;
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

            CreateMap<ManageModels.Artist, Album>()
                    .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Name))
                    .ForAllMembers(o => o.Condition((src, dest, value) => value != null));

            CreateMap<AggregationModels.AlbumStatistic, Album>()
                    .ForMember(dest => dest.Tracks, opt => opt.MapFrom(src => src.NumberOfTracks))
                    .ForMember(dest => dest.PlayTimeInMilliseconds, opt => opt.MapFrom(src => src.PlayTimeInMilliseconds))
                    .ForMember(dest => dest.SizeInBytes, opt => opt.MapFrom(src => src.SizeInBytes))
                    .ForAllMembers(o => o.Condition((src, dest, value) => value != null));

            CreateMap<SearchModels.Album, Album>()
                    .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistId))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForAllMembers(o => o.Condition((src, dest, value) => value != null));

            CreateMap<ManageModels.Album, Album>()
                    .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistId))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForAllMembers(o => o.Condition((src, dest, value) => value != null));
        }
    }
}
