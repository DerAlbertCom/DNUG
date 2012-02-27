using System;

namespace UserGroup.Entities
{
    public interface ISlug
    {
        string Slug { get; }
        void SetSlug(string slug);
    }
}