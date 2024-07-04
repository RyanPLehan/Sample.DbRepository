using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Genres.Requests
{
    public class Add : IRequest<Genre>
    {
        public string Name { get; set; }
    }
}
