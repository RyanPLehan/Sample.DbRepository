using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Manage.Artists.Requests;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Artists.Handlers
{
    internal sealed class AddHandler : IRequestHandler<Add, Artist>
    {
        private readonly IArtistRepository _repository;

        public AddHandler(IArtistRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Artist> Handle(Add request, CancellationToken cancellationToken)
        {
            Artist entity = new Artist()
            {
                Name = request.Name.Trim(),
            };

            return await _repository.Add(entity);
        }
    }
}
