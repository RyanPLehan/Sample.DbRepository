using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Albums.Requests
{
    public class Update : IRequest<Album>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
