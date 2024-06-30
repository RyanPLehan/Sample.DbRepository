using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Tracks.Requests;

namespace Sample.DbRepository.Domain.Management.Tracks.Handlers
{
    internal sealed class DeleteByIdsHandler : IRequestHandler<DeleteByIds, Unit>
    {
        private readonly ITrackRepository _repository;
        private readonly IMediator _mediator;

        public DeleteByIdsHandler(ITrackRepository repository,
                                  IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            ArgumentNullException.ThrowIfNull(mediator, nameof(mediator));

            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteByIds request, CancellationToken cancellationToken)
        {
            // Automatically direct child tables just incase there is no casading deletes
            await DeleteTracks(request.Id);
            await _repository.Delete(request.Id);
            return Unit.Value;
        }

        private async Task DeleteTracks(int TrackId)
        {
            var wpDelete = new RequestWordPart.DeleteById() { WordId = wordId };
            await _mediator.Send(wpDelete);
        }
    }
}
