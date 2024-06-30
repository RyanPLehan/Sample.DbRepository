using System;
using MediatR;

namespace Sample.DbRepository.Domain.Management.Albums.Requests
{
    public class Delete : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
