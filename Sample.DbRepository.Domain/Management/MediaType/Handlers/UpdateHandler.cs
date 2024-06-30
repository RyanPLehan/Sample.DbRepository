using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.MediaTypes.Requests;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.MediaTypes.Handlers
{
    internal sealed class UpdateHandler : IRequestHandler<Update, MediaType>
    {
        private readonly IMediaTypeRepository _repository;

        public UpdateHandler(IMediaTypeRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }


        public async Task<MediaType> Handle(Update request, CancellationToken cancellationToken)
        {
            MediaType entity = await _repository.GetForUpdate(request.Id);
            if (entity != null)
            {
                entity.Name = request.Name;
                entity = await _repository.Update(entity);
            }

            return entity;
        }

    }
}
