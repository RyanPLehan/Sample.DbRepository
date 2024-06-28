using System;
using MediatR;
using Sample.DbRepository.Domain.Models;

namespace Sample.DbRepository.Domain.Management.Artists.Requests
{
    public class Fetch : IRequest<Artist>
    {
        public int Id { get; set; }
    }
}
