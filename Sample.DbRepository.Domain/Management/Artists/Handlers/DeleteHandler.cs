using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Models;
using Sample.DbRepository.Domain.Management.Artists.Requests;

namespace Sample.DbRepository.Domain.Management.Artists.Handlers
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
            // Automatically direct child tables just incase there is no casading deletes
            await DeleteAlbums(request.Id);
            await _repository.Delete(request.Id);
            return Unit.Value;
        }

        private async Task DeleteAlbums(int ArtistId)
        {
            var wpDelete = new RequestWordPart.DeleteById() { WordId = wordId };
            await _mediator.Send(wpDelete);
        }
    }
}
