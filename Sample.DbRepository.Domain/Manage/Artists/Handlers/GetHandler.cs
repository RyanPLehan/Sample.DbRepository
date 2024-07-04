using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;
using Sample.DbRepository.Domain.Manage.Artists.Requests;

namespace Sample.DbRepository.Domain.Manage.Artists.Handlers
{
    internal class GetHandler : IRequestHandler<Get, Artist>
    {
        private readonly IArtistRepository _repository;

        public GetHandler(IArtistRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Artist> Handle(Get request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }

    }
}
