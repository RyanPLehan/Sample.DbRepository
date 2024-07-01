using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Search.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Handlers
{
    internal class GetHandler : IRequestHandler<Get, IEnumerable<Track>>
    {
        private readonly ITrackRepository _repository;

        public GetHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Track>> Handle(Get request, CancellationToken cancellationToken)
        {
            int skip = BatchHelper.ApplySkip(request.Skip);
            int take = BatchHelper.ApplySkip(request.Take);

            return await _repository.Get(skip, take);
        }
    }
}
