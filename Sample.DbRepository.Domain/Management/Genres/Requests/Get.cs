using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Genres.Requests
{
    public class Get : IRequest<Genre>
    {
        public int Id { get; set; }
    }
}
