using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Artists.Requests
{
    public class Add : IRequest<Artist>
    {
        public string Name { get; set; }
    }
}
