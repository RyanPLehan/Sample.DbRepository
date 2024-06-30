using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Artists.Requests;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Artists.Handlers
{
    internal class FetchHandler : IRequestHandler<Fetch, Artist>
    {
        private readonly IArtistRepository _repository;

        public FetchHandler(IArtistRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Artist> Handle(Fetch request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }

    }
}
