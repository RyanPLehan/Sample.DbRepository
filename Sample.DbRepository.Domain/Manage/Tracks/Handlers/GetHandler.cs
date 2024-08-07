﻿using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Manage.Tracks.Requests;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Tracks.Handlers
{
    internal class GetHandler : IRequestHandler<Get, Track>
    {
        private readonly ITrackRepository _repository;

        public GetHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Track> Handle(Get request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }

    }
}
