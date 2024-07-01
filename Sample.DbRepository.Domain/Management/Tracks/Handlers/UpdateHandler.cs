using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Tracks.Requests;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Tracks.Handlers
{
    internal sealed class UpdateHandler : IRequestHandler<Update, Track>
    {
        private readonly ITrackRepository _repository;

        public UpdateHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }


        public async Task<Track> Handle(Update request, CancellationToken cancellationToken)
        {
            Track entity = await _repository.GetForUpdate(request.Id);
            if (entity != null)
            {
                entity.Name = request.Name?.Trim();
                entity.GenreId = request.GenreId;
                entity.Composer = request.Composer?.Trim();
            }

            return entity;
        }

    }
}
