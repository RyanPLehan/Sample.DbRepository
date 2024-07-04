using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Artists.Requests
{
    public class Update : IRequest<Artist>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
