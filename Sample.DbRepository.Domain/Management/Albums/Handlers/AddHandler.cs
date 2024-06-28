using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Formatters;
using Sample.DbRepository.Domain.Models;
using Sample.DbRepository.Domain.Management.Albums.Requests;

namespace Sample.DbRepository.Domain.Management.Albums.Handlers
{
    internal sealed class AddHandler : IRequestHandler<Add, Album>
    {
        private readonly IAlbumRepository _repository;

        public AddHandler(IAlbumRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Album> Handle(Add request, CancellationToken cancellationToken)
        {
            Album entity = new Album()
            {
                Title = request.Title.Trim(),
                ArtistId = request.ArtistId,
            };

            return await _repository.Add(entity);
        }
    }
}
