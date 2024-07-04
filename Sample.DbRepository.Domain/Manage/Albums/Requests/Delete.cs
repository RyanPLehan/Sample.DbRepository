using System;
using MediatR;

namespace Sample.DbRepository.Domain.Manage.Albums.Requests
{
    public class Delete : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
