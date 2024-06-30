using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Genres.Requests;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Genres.Handlers
{
    internal class FetchHandler : IRequestHandler<Fetch, Genre>
    {
        private readonly IGenreRepository _repository;

        public FetchHandler(IGenreRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Genre> Handle(Fetch request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }

    }
}
