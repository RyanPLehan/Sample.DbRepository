using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Genres.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Genres.Handlers
{
    internal class FindByNameHandler : IRequestHandler<FindByName, IEnumerable<Genre>>
    {
        private readonly IGenreRepository _repository;

        public FindByNameHandler(IGenreRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Genre>> Handle(FindByName request, CancellationToken cancellationToken)
        {
            return await _repository.FindByName(request.Name);
        }
    }
}
