using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Albums.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Handlers
{
    internal class FindByArtistNameHandler : IRequestHandler<FindByArtistName, IEnumerable<AlbumArtist>>
    {
        private readonly IAlbumRepository _repository;

        public FindByArtistNameHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumArtist>> Handle(FindByArtistName request, CancellationToken cancellationToken)
        {
            return await _repository.FindByArtistName(request.ArtistName);
        }
    }
}
