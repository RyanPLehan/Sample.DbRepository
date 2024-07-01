using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Aggregation.Artists.Requests;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Artists.Handlers
{
    internal class GetCountHandler : IRequestHandler<GetCount, int>
    {
        private readonly IArtistRepository _repository;

        public GetCountHandler(IArtistRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<int> Handle(GetCount request, CancellationToken cancellationToken)
        {
            return await _repository.GetCount();
        }
    }
}
