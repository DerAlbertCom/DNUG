using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    public interface IDatabaseContext : IDisposable
    {
        DbContext DbContext { get; }
    }
}