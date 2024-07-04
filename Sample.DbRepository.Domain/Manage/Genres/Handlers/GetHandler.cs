using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Manage.Genres.Requests;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Genres.Handlers
{
    internal class GetHandler : IRequestHandler<Get, Genre>
    {
        private readonly IGenreRepository _repository;

        public GetHandler(IGenreRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Genre> Handle(Get request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }

    }
}
