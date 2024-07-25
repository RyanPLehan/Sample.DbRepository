using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Search.Albums.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Handlers
{
    internal class GetAllHandler : IRequestHandler<GetAll, IEnumerable<AlbumArtist>>
    {
        private const int MAX_TAKE = 250;
        private readonly IAlbumRepository _repository;

        public GetAllHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumArtist>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            int skip = BatchHelper.ApplySkip(request.Skip);
            int take = BatchHelper.ApplyTake(request.Take, MAX_TAKE);

            return await _repository.GetAll(skip, take);
        }
    }
}
