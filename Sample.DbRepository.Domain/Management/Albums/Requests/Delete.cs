using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Models;

namespace Sample.DbRepository.Domain.Management.Albums.Requests
{
    public class Delete : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
