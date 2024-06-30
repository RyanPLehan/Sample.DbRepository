using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.MediaTypes.Requests
{
    public class Update : IRequest<MediaType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
