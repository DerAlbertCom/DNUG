using System;

namespace UserGroup.Entities
{
    public interface ISlug
    {
        string Slug { get; set; }
        void SetSlug(string slug);
    }

    public static class SlugExtensions
    {
        public static void SetSlugInternal(this ISlug container, string slug, int maxLength)
        {
            container.Slug= slug.Substring(0, Math.Min(slug.Length, maxLength)) ;
        }
    }
}