using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Albums.Requests
{
    public class Get : IRequest<Album>
    {
        public int Id { get; set; }
    }
}
