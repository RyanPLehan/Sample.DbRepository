using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Artists.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Artists.Handlers
{
    internal class FindByNameHandler : IRequestHandler<FindByName, IEnumerable<Artist>>
    {
        private readonly IArtistRepository _repository;

        public FindByNameHandler(IArtistRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Artist>> Handle(FindByName request, CancellationToken cancellationToken)
        {
            return await _repository.FindByName(request.Name);
        }
    }
}
