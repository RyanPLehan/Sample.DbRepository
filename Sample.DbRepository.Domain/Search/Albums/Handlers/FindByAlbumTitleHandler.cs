using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Albums.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Handlers
{
    internal class FindByAlbumTitleHandler : IRequestHandler<FindByAlbumTitle, IEnumerable<AlbumArtist>>
    {
        private readonly IAlbumRepository _repository;

        public FindByAlbumTitleHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumArtist>> Handle(FindByAlbumTitle request, CancellationToken cancellationToken)
        {
            return await _repository.FindByAlbumTitle(request.Title);
        }
    }
}
