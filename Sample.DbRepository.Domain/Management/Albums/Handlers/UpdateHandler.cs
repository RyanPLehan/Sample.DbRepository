using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Formatters;
using Sample.DbRepository.Domain.Management.Albums.Requests;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Albums.Handlers
{
    internal sealed class UpdateHandler : IRequestHandler<Update, Album>
    {
        private readonly IAlbumRepository _repository;

        public UpdateHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }


        public async Task<Album> Handle(Update request, CancellationToken cancellationToken)
        {
            Album entity = await _repository.GetForUpdate(request.Id);
            if (entity != null)
            {
                entity.Title = request.Title;
                entity = await _repository.Update(entity);
            }

            return entity;
        }

    }
}
