using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.MediaTypes.Requests
{
    public class Fetch : IRequest<MediaType>
    {
        public int Id { get; set; }
    }
}
