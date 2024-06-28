using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Models;

namespace Sample.DbRepository.Domain.Management.Albums.Requests
{
    public class DeleteByIds : IRequest<Unit>
    {
        public IEnumerable<int> Ids { get; set; } = Enumerable.Empty<int>();
    }
}
