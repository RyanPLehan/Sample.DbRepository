using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Search.Genres.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Genres.Handlers
{
    internal class GetHandler : IRequestHandler<Get, IEnumerable<Genre>>
    {
        private readonly IGenreRepository _repository;

        public GetHandler(IGenreRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Genre>> Handle(Get request, CancellationToken cancellationToken)
        {
            int skip = BatchHelper.ApplySkip(request.Skip);
            int take = BatchHelper.ApplySkip(request.Take);

            return await _repository.Get(skip, take);
        }
    }
}
