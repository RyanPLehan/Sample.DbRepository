using System;
using AutoMapper;
using Sample.DbRepository.Domain.AutoMapper.Converters;

namespace Sample.DbRepository.Domain.AutoMapper.Profiles
{
    public sealed class ConvertersMappingProfile : Profile
    {
        public ConvertersMappingProfile()
        {
            CreateMap<string, int>()
                .ConvertUsing(new StringIntConverter());

            CreateMap<string, string>()
                .ConvertUsing(new StringTrimmedStringConverter());

            CreateMap<Guid?, Guid>()
                .ConvertUsing(new NullableGuidConverter());
        }
    }
}
