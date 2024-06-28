using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Models;
using Sample.DbRepository.Domain.Management.Albums.Requests;

namespace Sample.DbRepository.Domain.Management.Albums.Handlers
{
    internal class FetchHandler : IRequestHandler<Fetch, Album>
    {
        private readonly IAlbumRepository _repository;

        public FetchHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Album> Handle(Fetch request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }

    }
}
