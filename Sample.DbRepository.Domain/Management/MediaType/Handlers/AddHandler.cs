using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.MediaTypes.Requests;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.MediaTypes.Handlers
{
    internal sealed class AddHandler : IRequestHandler<Add, MediaType>
    {
        private readonly IMediaTypeRepository _repository;

        public AddHandler(IMediaTypeRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<MediaType> Handle(Add request, CancellationToken cancellationToken)
        {
            MediaType entity = new MediaType()
            {
                Name = request.Name.Trim(),
            };

            return await _repository.Add(entity);
        }
    }
}
