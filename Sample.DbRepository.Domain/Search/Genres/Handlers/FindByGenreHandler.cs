using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Genres.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Genres.Handlers
{
    internal class FindByGenreHandler : IRequestHandler<FindByGenre, Genre>
    {
        private readonly IGenreRepository _repository;

        public FindByGenreHandler(IGenreRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Genre> Handle(FindByGenre request, CancellationToken cancellationToken)
        {
            return await _repository.FindByGenre(request.GenreId);
        }
    }
}
