using System;
using MediatR;


namespace Sample.DbRepository.Domain.Manage.Genres.Requests
{
    public class Delete : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
