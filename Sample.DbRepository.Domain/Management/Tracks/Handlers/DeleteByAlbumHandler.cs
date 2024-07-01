using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Tracks.Requests;

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
            var findRequest = new FindByAlbum() { AlbumId = request.AlbumId };
            var tracks = await _mediator.Send(findRequest);

            await _repository.Delete(tracks.Select(x => x.Id).ToArray());
            return Unit.Value;
        }
    }
}
