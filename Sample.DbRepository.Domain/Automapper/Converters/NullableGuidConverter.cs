using System;
using AutoMapper;

namespace Sample.DbRepository.Domain.AutoMapper.Converters
{
    public sealed class NullableGuidConverter : ITypeConverter<Guid?, Guid>
    {
        public Guid Convert(Guid? source, Guid destination, ResolutionContext context)
        {
            Guid ret = Guid.Empty;
            if (source.HasValue)
                ret = source.Value;

            return ret;
        }
    }
}
