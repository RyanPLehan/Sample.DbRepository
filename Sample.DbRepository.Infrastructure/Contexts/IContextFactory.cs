using System;
using Microsoft.EntityFrameworkCore;

namespace Sample.DbRepository.Infrastructure
{
    public interface IContextFactory<TContext>
        where TContext : DbContext
    {
        TContext CreateCommandContext();
        TContext CreateQueyContext();
    }
}
