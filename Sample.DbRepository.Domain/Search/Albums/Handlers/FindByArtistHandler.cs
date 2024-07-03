using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Albums.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Handlers
{
    internal class FindByArtistHandler : IRequestHandler<FindByArtist, IEnumerable<AlbumArtist>>
    {
        private readonly IAlbumRepository _repository;

        public FindByArtistHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumArtist>> Handle(FindByArtist request, CancellationToken cancellationToken)
        {
            return await _repository.FindByArtist(request.ArtistId);
        }
    }
}
