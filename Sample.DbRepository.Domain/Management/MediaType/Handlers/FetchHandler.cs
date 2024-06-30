using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.MediaTypes.Requests;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.MediaTypes.Handlers
{
    internal class FetchHandler : IRequestHandler<Fetch, MediaType>
    {
        private readonly IMediaTypeRepository _repository;

        public FetchHandler(IMediaTypeRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<MediaType> Handle(Fetch request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }

    }
}
