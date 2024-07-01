using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Genres.Requests;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Genres.Handlers
{
    internal sealed class AddHandler : IRequestHandler<Add, Genre>
    {
        private readonly IGenreRepository _repository;

        public AddHandler(IGenreRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Genre> Handle(Add request, CancellationToken cancellationToken)
        {
            Genre entity = new Genre()
            {
                Name = request.Name.Trim(),
            };

            return await _repository.Add(entity);
        }
    }
}
