﻿using System;
using MediatR;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Albums.Requests
{
    public class Fetch : IRequest<Album>
    {
        public int Id { get; set; }
    }
}
