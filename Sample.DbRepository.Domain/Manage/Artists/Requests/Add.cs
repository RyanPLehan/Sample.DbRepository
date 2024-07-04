using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Artists.Requests
{
    public class Add : IRequest<Artist>
    {
        public string Name { get; set; }
    }
}
