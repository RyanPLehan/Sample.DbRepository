using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Albums.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Handlers
{
    internal class FindByArtistsHandler : IRequestHandler<FindByArtists, IEnumerable<AlbumArtist>>
    {
        private readonly IAlbumRepository _repository;

        public FindByArtistsHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumArtist>> Handle(FindByArtists request, CancellationToken cancellationToken)
        {
            return await _repository.FindByAlbum(request.ArtistIds);
        }
    }
}
