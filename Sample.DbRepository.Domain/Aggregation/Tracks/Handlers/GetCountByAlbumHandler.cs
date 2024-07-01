using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Tracks.Requests;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Tracks.Handlers
{
    internal class GetCountByAlbumHandler : IRequestHandler<GetCountByAlbum, IDictionary<int,int>>
    {
        private readonly ITrackRepository _repository;

        public GetCountByAlbumHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IDictionary<int, int>> Handle(GetCountByAlbum request, CancellationToken cancellationToken)
        {
            return await _repository.GetCountByAlbum();
        }
    }
}
