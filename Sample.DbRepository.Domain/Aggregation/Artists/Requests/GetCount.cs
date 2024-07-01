﻿using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Artists.Requests
{
    public class GetCount : IRequest<int>
    {
    }
}
