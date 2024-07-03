using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Artists.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Artists.Handlers
{
    internal class FindByArtistsHandler : IRequestHandler<FindByArtists, IEnumerable<Artist>>
    {
        private readonly IArtistRepository _repository;

        public FindByArtistsHandler(IArtistRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Artist>> Handle(FindByArtists request, CancellationToken cancellationToken)
        {
            return await _repository.FindByArtist(request.ArtistIds);
        }
    }
}
