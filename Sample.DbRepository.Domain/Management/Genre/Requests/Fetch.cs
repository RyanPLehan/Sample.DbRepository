using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Genres.Requests
{
    public class Fetch : IRequest<Genre>
    {
        public int Id { get; set; }
    }
}
