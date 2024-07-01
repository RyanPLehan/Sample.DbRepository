using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Handlers
{
    internal class FindByNameHandler : IRequestHandler<FindByName, IEnumerable<Track>>
    {
        private readonly ITrackRepository _repository;

        public FindByNameHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Track>> Handle(FindByName request, CancellationToken cancellationToken)
        {
            return await _repository.FindByName(request.Name);
        }
    }
}
