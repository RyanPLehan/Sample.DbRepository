using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Manage.Albums.Requests;
using TrackManage = Sample.DbRepository.Domain.Manage.Tracks.Requests;
using TrackSearch = Sample.DbRepository.Domain.Search.Tracks.Requests;

namespace Sample.DbRepository.Domain.Manage.Albums.Handlers
{
    internal sealed class DeleteHandler : IRequestHandler<Delete, Unit>
    {
        private readonly IAlbumRepository _repository;
        private readonly IMediator _mediator;

        public DeleteHandler(IAlbumRepository repository,
                             IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            ArgumentNullException.ThrowIfNull(mediator, nameof(mediator));

            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(Delete request, CancellationToken cancellationToken)
        {
            // No Casading Deletes, must do it manually (should implement transactions)
            await DeleteTracks(request.Id);
            await _repository.Delete(request.Id);
            return Unit.Value;
        }

        private async Task DeleteTracks(int albumId)
        {
            var findRequest = new TrackSearch.FindByAlbum() { AlbumId = albumId };
            var tracks = await _mediator.Send(findRequest);

            var deleteRequest = new TrackManage.DeleteByIds() { Ids = tracks.Select(x => x.TrackId).ToArray() };
            await _mediator.Send(deleteRequest);
        }
    }
}
