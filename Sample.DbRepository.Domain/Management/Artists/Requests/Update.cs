using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Models;

namespace Sample.DbRepository.Domain.Management.Artists.Requests
{
    public class Update : IRequest<Artist>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
