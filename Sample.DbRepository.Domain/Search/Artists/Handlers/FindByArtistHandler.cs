using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Artists.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Artists.Handlers
{
    internal class FindByArtistHandler : IRequestHandler<FindByArtist, Artist>
    {
        private readonly IArtistRepository _repository;

        public FindByArtistHandler(IArtistRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Artist> Handle(FindByArtist request, CancellationToken cancellationToken)
        {
            return await _repository.FindByArtist(request.ArtistId);
        }
    }
}
