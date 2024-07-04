using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Albums.Requests
{
    public class Update : IRequest<Album>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
