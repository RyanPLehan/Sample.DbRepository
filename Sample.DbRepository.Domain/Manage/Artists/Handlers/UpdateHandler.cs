using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Manage.Artists.Requests;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Artists.Handlers
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
