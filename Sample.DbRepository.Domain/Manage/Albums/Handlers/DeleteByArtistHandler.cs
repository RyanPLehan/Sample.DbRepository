using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Manage.Albums.Requests;
using TrackManage = Sample.DbRepository.Domain.Manage.Tracks.Requests;
using TrackSearch = Sample.DbRepository.Domain.Search.Tracks.Requests;

namespace Sample.DbRepository.Domain.Manage.Albums.Handlers
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
            // No Casading Deletes, must do it manually (should implement transactions)
            var albums = await FindAlbums(request.ArtistId);
            var albumIds = albums.Select(x => x.AlbumId).ToArray();
            await DeleteTracks(albumIds);
            await _repository.Delete(albumIds);
            return Unit.Value;
        }

        private async Task<IEnumerable<Search.Models.AlbumArtist>> FindAlbums(int artistId)
        {
            var findRequest = new Search.Albums.Requests.FindByArtist() { ArtistId = artistId };
            return await _mediator.Send(findRequest);
        }


        private async Task DeleteTracks(IEnumerable<int> albumIds)
        {
            var findRequest = new TrackSearch.FindByAlbums() { AlbumIds = albumIds };
            var tracks = await _mediator.Send(findRequest);

            var deleteRequest = new TrackManage.DeleteByIds() { Ids = tracks.Select(x => x.TrackId).ToArray() };
            await _mediator.Send(deleteRequest);
        }
    }
}
