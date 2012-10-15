using System.Web.Mvc;
using WikiPlex;

namespace UserGroup.Web.Extensions
{
    public static class WikiExtensions
    {
        static readonly WikiEngine _engine = new WikiEngine();

        static WikiExtensions()
        {
        }

        public static MvcHtmlString Wiki(this HtmlHelper helper, string text)
        {
            return new MvcHtmlString(_engine.Render(text));
        }
    }
}