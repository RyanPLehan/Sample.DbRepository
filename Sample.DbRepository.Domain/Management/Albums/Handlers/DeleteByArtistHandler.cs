using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Models;
using Sample.DbRepository.Domain.Management.Albums.Requests;

namespace Sample.DbRepository.Domain.Management.Albums.Handlers
{
    internal sealed class DeleteByArtistHandler : IRequestHandler<DeleteByArtist, Unit>
    {
        private readonly IAlbumRepository _repository;
        private readonly IMediator _mediator;

        public DeleteByArtistHandler(IAlbumRepository repository,
                                     IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            ArgumentNullException.ThrowIfNull(mediator, nameof(mediator));

            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteByArtist request, CancellationToken cancellationToken)
        {
            // Automatically direct child tables just incase there is no casading deletes
            // In the real world, this would be wrapped in a transaction
            await DeleteTracks(request.ArtistId);
            await _repository.Delete(request.ArtistId);
            return Unit.Value;
        }

        private async Task DeleteTracks(int albumId)
        {
            var wpDelete = new RequestWordPart.DeleteById() { WordId = wordId };
            await _mediator.Send(wpDelete);
        }
    }
}
