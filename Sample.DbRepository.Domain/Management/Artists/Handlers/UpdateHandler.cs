using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Formatters;
using Sample.DbRepository.Domain.Models;
using Sample.DbRepository.Domain.Management.Artists.Requests;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Sample.DbRepository.Domain.Management.Artists.Handlers
{
    internal sealed class UpdateHandler : IRequestHandler<Update, Artist>
    {
        private readonly IArtistRepository _repository;

        public UpdateHandler(IArtistRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }


        public async Task<Artist> Handle(Update request, CancellationToken cancellationToken)
        {
            Artist entity = await _repository.GetForUpdate(request.Id);
            if (entity != null)
            {
                entity.Name = request.Name;
                entity = await _repository.Update(entity);
            }

            return entity;
        }

    }
}
