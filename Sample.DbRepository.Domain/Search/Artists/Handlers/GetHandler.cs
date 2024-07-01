using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Search.Artists.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Artists.Handlers
{
    internal class GetHandler : IRequestHandler<Get, IEnumerable<Artist>>
    {
        private readonly IArtistRepository _repository;

        public GetHandler(IArtistRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Artist>> Handle(Get request, CancellationToken cancellationToken)
        {
            int skip = BatchHelper.ApplySkip(request.Skip);
            int take = BatchHelper.ApplySkip(request.Take);

            return await _repository.Get(skip, take);
        }
    }
}
