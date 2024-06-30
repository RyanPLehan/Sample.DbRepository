using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Tracks.Requests;

namespace Sample.DbRepository.Domain.Management.Tracks.Handlers
{
    internal sealed class DeleteByAlbumHandler : IRequestHandler<DeleteByAlbum, Unit>
    {
        private readonly ITrackRepository _repository;
        private readonly IMediator _mediator;

        public DeleteByAlbumHandler(ITrackRepository repository,
                                     IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            ArgumentNullException.ThrowIfNull(mediator, nameof(mediator));

            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteByAlbum request, CancellationToken cancellationToken)
        {
            await _repository.DeleteByAlbum(request.AlbumId);
            return Unit.Value;
        }
    }
}
