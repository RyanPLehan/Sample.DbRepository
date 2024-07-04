using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Manage.Genres.Requests;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Genres.Handlers
{
    internal sealed class UpdateHandler : IRequestHandler<Update, Genre>
    {
        private readonly IGenreRepository _repository;

        public UpdateHandler(IGenreRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }


        public async Task<Genre> Handle(Update request, CancellationToken cancellationToken)
        {
            Genre entity = await _repository.GetForUpdate(request.Id);
            if (entity != null)
            {
                entity.Name = request.Name;
                entity = await _repository.Update(entity);
            }

            return entity;
        }

    }
}
