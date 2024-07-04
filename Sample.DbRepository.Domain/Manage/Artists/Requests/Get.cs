using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Artists.Requests
{
    public class Get : IRequest<Artist>
    {
        public int Id { get; set; }
    }
}
