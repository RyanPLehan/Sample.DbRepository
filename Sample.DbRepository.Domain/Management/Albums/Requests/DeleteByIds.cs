﻿using System;
using MediatR;

namespace Sample.DbRepository.Domain.Management.Albums.Requests
{
    public class DeleteByIds : IRequest<Unit>
    {
        public IEnumerable<int> Ids { get; set; } = Enumerable.Empty<int>();
    }
}
