using System;

namespace Sample.DbRepository.Domain
{
    public sealed class ApiValidationError
    {
        public string Code { get; set; }
        public string Context { get; set; }
        public string Message { get; set; }
    }
}
