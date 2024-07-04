using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Manage.Artists.Requests;
using AlbumManage = Sample.DbRepository.Domain.Manage.Albums.Requests;
using AlbumSearch = Sample.DbRepository.Domain.Search.Albums.Requests;

namespace Sample.DbRepository.Domain.Manage.Artists.Handlers
{
    internal sealed class DeleteHandler : IRequestHandler<Delete, Unit>
    {
        private readonly IArtistRepository _repository;
        private readonly IMediator _mediator;

        public DeleteHandler(IArtistRepository repository,
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
            await DeleteAlbums(request.Id);
            await _repository.Delete(request.Id);
            return Unit.Value;
        }

        private async Task DeleteAlbums(int artistId)
        {
            var findRequest = new AlbumSearch.FindByArtist() { ArtistId = artistId };
            var albums = await _mediator.Send(findRequest);

            var deleteRequest = new AlbumManage.DeleteByIds() { Ids = albums.Select(x => x.AlbumId).ToArray() };
            await _mediator.Send(deleteRequest);
        }
    }
}
