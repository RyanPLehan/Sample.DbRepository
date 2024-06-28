using System;
using AutoMapper;

namespace Sample.DbRepository.Domain.AutoMapper.Converters
{
    public sealed class StringIntConverter : ITypeConverter<string, int>
    {
        public int Convert(string source, int destination, ResolutionContext context)
        {
            int ret = 0;

            if (!String.IsNullOrWhiteSpace(source))
                Int32.TryParse(source, out ret);

            return ret;
        }
    }
}
