using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Albums.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Handlers
{
    internal class FindByAlbumHandler : IRequestHandler<FindByAlbum, AlbumArtist>
    {
        private readonly IAlbumRepository _repository;

        public FindByAlbumHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<AlbumArtist> Handle(FindByAlbum request, CancellationToken cancellationToken)
        {
            return await _repository.FindByAlbum(request.AlbumId);
        }
    }
}
