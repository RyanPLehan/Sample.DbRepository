using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Tracks.Requests;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Tracks.Handlers
{
    internal class GetPlayTimeByAlbumHandler : IRequestHandler<GetPlayTimeByAlbum, IDictionary<int,long>>
    {
        private readonly ITrackRepository _repository;

        public GetPlayTimeByAlbumHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IDictionary<int, long>> Handle(GetPlayTimeByAlbum request, CancellationToken cancellationToken)
        {
            return await _repository.GetPlayTimeByAlbum();
        }
    }
}
