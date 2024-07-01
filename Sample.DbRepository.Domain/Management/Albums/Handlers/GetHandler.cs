using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;
using Sample.DbRepository.Domain.Management.Albums.Requests;

namespace Sample.DbRepository.Domain.Management.Albums.Handlers
{
    internal class GetHandler : IRequestHandler<Get, Album>
    {
        private readonly IAlbumRepository _repository;

        public GetHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Album> Handle(Get request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }

    }
}
