using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Genres.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Genres.Handlers
{
    internal class FindByGenresHandler : IRequestHandler<FindByGenres, IEnumerable<Genre>>
    {
        private readonly IGenreRepository _repository;

        public FindByGenresHandler(IGenreRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Genre>> Handle(FindByGenres request, CancellationToken cancellationToken)
        {
            return await _repository.FindByGenre(request.GenreIds);
        }
    }
}
