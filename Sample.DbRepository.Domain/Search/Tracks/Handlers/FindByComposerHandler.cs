using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Handlers
{
    internal class FindByComposerHandler : IRequestHandler<FindByComposer, IEnumerable<Track>>
    {
        private readonly ITrackRepository _repository;

        public FindByComposerHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Track>> Handle(FindByComposer request, CancellationToken cancellationToken)
        {
            return await _repository.FindByComposer(request.Composer);
        }
    }
}
