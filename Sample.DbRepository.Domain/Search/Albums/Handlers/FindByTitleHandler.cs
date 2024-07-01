using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Albums.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Handlers
{
    internal class FindByTitleHandler : IRequestHandler<FindByName, IEnumerable<Album>>
    {
        private readonly IAlbumRepository _repository;

        public FindByTitleHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Album>> Handle(FindByName request, CancellationToken cancellationToken)
        {
            return await _repository.FindByTitle(request.Title);
        }
    }
}
