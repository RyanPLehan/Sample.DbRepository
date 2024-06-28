using System;
using AutoMapper;

namespace Sample.DbRepository.Domain.AutoMapper.Converters
{
    public sealed class StringTrimmedStringConverter : ITypeConverter<string, string>
    {
        public string Convert(string source, string destination, ResolutionContext context)
        {
            return source == null ? source : source.Trim();
        }
    }
}