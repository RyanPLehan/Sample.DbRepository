using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Genres.Requests;
using TrackManage = Sample.DbRepository.Domain.Management.Tracks.Requests;
using TrackSearch = Sample.DbRepository.Domain.Search.Tracks.Requests;

namespace Sample.DbRepository.Domain.Management.Genres.Handlers
{
    internal sealed class DeleteHandler : IRequestHandler<Delete, Unit>
    {
        private readonly IGenreRepository _repository;
        private readonly IMediator _mediator;

        public DeleteHandler(IGenreRepository repository,
                             IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            ArgumentNullException.ThrowIfNull(mediator, nameof(mediator));

            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(Delete request, CancellationToken cancellationToken)
        {
            // There are no referential constraints, but we should nullify any tracks that point to this genre
            await DeReferenceTracks(request.Id);
            await _repository.Delete(request.Id);
            return Unit.Value;
        }

        private async Task DeReferenceTracks(int genreId)
        {
            var findRequest = new TrackSearch.FindByGenre() { GenreId = genreId };
            var tracks = await _mediator.Send(findRequest);

            // Obviously, at this point we would use a better method of updating, but for now we will just iterate one by one
            foreach (var track in tracks)
            {
                var updateRequest = new TrackManage.Update()
                {
                    Id = track.TrackId,
                    Name = track.TrackName,
                    Composer = track.Composer,
                    GenreId = null,
                };

                await _mediator.Send(updateRequest);
            }
        }
    }
}
