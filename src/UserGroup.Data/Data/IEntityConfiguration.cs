using System;
using System.Data.Entity.ModelConfiguration;

namespace UserGroup.Data
{
    public interface IEntityConfiguration<T> where T : class
    {
        void Configure(EntityTypeConfiguration<T> configuration);
    }
}