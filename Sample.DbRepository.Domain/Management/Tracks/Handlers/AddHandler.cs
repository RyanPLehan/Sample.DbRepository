using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Tracks.Requests;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Tracks.Handlers
{
    internal sealed class AddHandler : IRequestHandler<Add, Track>
    {
        private readonly ITrackRepository _repository;

        public AddHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Track> Handle(Add request, CancellationToken cancellationToken)
        {
            Track entity = new Track()
            {
                Name = request.Name?.Trim(),
                AlbumId = request.AlbumId,
                GenreId = request.GenreId,
                Composer = request.Composer?.Trim(),
                PlayTimeInMilliseconds = request.PlayLengthInMilliseconds,
                SizeInBytes = request.SizeInBytes,
            };

            return await _repository.Add(entity);
        }
    }
}