using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Search.Albums.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Handlers
{
    internal class GetHandler : IRequestHandler<Get, IEnumerable<Album>>
    {
        private readonly IAlbumRepository _repository;

        public GetHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Album>> Handle(Get request, CancellationToken cancellationToken)
        {
            int skip = BatchHelper.ApplySkip(request.Skip);
            int take = BatchHelper.ApplySkip(request.Take);

            return await _repository.Get(skip, take);
        }
    }
}
