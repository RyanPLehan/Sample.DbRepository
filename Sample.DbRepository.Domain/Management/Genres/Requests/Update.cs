using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Genres.Requests
{
    public class Update : IRequest<Genre>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
