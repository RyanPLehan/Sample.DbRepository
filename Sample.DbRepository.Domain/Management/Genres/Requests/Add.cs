using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Genres.Requests
{
    public class Add : IRequest<Genre>
    {
        public string Name { get; set; }
    }
}
