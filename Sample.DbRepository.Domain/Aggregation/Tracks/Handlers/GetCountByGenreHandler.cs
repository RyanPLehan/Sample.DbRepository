using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Tracks.Requests;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Tracks.Handlers
{
    internal class GetCountByGenreHandler : IRequestHandler<GetCountByGenre, IDictionary<int,int>>
    {
        private readonly ITrackRepository _repository;

        public GetCountByGenreHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IDictionary<int, int>> Handle(GetCountByGenre request, CancellationToken cancellationToken)
        {
            return await _repository.GetCountByGenre();
        }
    }
}
