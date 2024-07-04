using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Genres.Requests
{
    public class Update : IRequest<Genre>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
