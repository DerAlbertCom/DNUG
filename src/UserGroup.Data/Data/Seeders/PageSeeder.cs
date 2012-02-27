using System.Collections.Generic;
using UserGroup.Entities;

namespace UserGroup.Data.Seeders
{
    public class PageSeeder
    {
        public IEnumerable<Page> GetPages()
        {
            yield return new Page
                             {
                                 Title = "Startseite",
                                 Slug = "homepage"
                             };
            yield return new Page
                             {
                                 Title = "Kontakt",
                                 Slug = "contact"
                             };
            yield return new Page
                             {
                                 Title = "Über uns",
                                 Slug = "about"
                             };
        }
    }
}