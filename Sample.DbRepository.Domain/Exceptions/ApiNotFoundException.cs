using System;
using System.Net;
using System.Net.Http;

namespace Sample.DbRepository.Domain
{
    public sealed class ApiNotFoundException : ApiException
    {
        public ApiNotFoundException()
            : base("Error occured while communicating with an external API")
        {
        }

        public ApiNotFoundException(HttpStatusCode statusCode)
            : base("Error occured while communicating with an external API", statusCode)
        {
        }

        public ApiNotFoundException(string message)
            : base(message)
        {
        }

        public ApiNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ApiNotFoundException(string message, Exception innerException, HttpStatusCode? statusCode)
            : base(message, innerException, statusCode)
        {
        }
    }
}
