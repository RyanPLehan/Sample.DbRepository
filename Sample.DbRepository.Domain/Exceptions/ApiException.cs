using System;
using System.Net;
using System.Net.Http;

namespace Sample.DbRepository.Domain
{
    public class ApiException : HttpRequestException
    {
        public ApiException()
            : base("Error occured while communicating with an external API")
        {
        }

        public ApiException(string message, HttpStatusCode statusCode)
            : base("Error occured while communicating with an external API", null, statusCode)
        {
        }

        public ApiException(string message)
            : base(message)
        {
        }

        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ApiException(string message, Exception innerException, HttpStatusCode? statusCode)
            : base(message, innerException, statusCode)
        {
        }
    }
}
