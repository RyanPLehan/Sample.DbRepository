using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Artists.Requests
{
    public class Get : IRequest<Artist>
    {
        public int Id { get; set; }
    }
}
