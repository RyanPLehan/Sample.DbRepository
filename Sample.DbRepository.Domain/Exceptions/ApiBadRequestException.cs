using System;
using System.Net;
using System.Net.Http;

namespace Sample.DbRepository.Domain
{
    public sealed class ApiBadRequestException : ApiException
    {
        public ApiBadRequestException()
            : base("Error occured while communicating with an external API")
        {
        }
        public ApiBadRequestException(HttpStatusCode statusCode)
            : base("Error occured while communicating with an external API", statusCode)
        {
        }

        public ApiBadRequestException(string message)
            : base(message)
        {
        }

        public ApiBadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ApiBadRequestException(string message, Exception innerException, HttpStatusCode? statusCode)
            : base(message, innerException, statusCode)
        {
        }
    }
}
