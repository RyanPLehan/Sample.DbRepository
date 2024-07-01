using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Albums.Requests;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Albums.Handlers
{
    internal class GetCountByArtistHandler : IRequestHandler<GetCountByArtist, IDictionary<int,int>>
    {
        private readonly IAlbumRepository _repository;

        public GetCountByArtistHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IDictionary<int, int>> Handle(GetCountByArtist request, CancellationToken cancellationToken)
        {
            return await _repository.GetCountByArtist();
        }
    }
}
