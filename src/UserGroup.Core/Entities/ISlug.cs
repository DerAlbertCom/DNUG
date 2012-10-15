using System;

namespace UserGroup.Entities
{
    public interface ISlug
    {
        string Slug { get; }
        void SetSlug(string slug);
    }

    public static class SlugExtensions
    {
        public static void SetSlug(this ISlug container, string slug, int maxLength)
        {
            container.SetSlug(slug.Substring(0, Math.Max(slug.Length, maxLength)));
        }
    }
}