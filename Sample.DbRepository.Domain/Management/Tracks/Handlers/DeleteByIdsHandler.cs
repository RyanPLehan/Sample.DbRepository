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
            await _repository.Delete(request.Ids);
            return Unit.Value;
        }
    }
}
