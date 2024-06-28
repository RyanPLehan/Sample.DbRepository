using System;
using Microsoft.EntityFrameworkCore;

namespace Sample.DbRepository.Domain.Infrastructure
{
    public interface IContextFactory<TContext>
        where TContext : DbContext
    {
        TContext CreateCommandContext();
        TContext CreateQueyContext();
    }
}
