﻿using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Albums.Requests;
using TrackManage = Sample.DbRepository.Domain.Management.Tracks.Requests;
using TrackSearch = Sample.DbRepository.Domain.Search.Tracks.Requests;

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
            // No Casading Deletes, must do it manually (should implement transactions)
            var albums = await FindAlbums(request.ArtistId);            
            await DeleteTracks(albums.Select(x => x.Id).ToArray());
            await _repository.Delete(albums.Select(x => x.Id).ToArray());
            return Unit.Value;
        }

        private async Task<IEnumerable<Search.Models.Album>> FindAlbums(int artistId)
        {
            var findRequest = new Search.Albums.Requests.FindByArtist() { ArtistId = artistId };
            return await _mediator.Send(findRequest);
        }


        private async Task DeleteTracks(IEnumerable<int> albumIds)
        {
            var findRequest = new TrackSearch.FindByAlbums() { AlbumIds = albumIds };
            var tracks = await _mediator.Send(findRequest);

            var deleteRequest = new TrackManage.DeleteByIds() { Ids = tracks.Select(x => x.Id).ToArray() };
            await _mediator.Send(deleteRequest);
        }
    }
}
