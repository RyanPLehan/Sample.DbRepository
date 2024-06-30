using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.MediaTypes.Requests
{
    public class Add : IRequest<MediaType>
    {
        public string Name { get; set; }
    }
}
