using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace UserGroup.Web.Extensions
{
    public static class DisplayExtensions
    {
        public static string DisplayFor<T>(this HtmlHelper<T> helper,
                                           Expression<Func<T, string>> expression,
                                           int maxLength)
        {
            var text = expression.Compile().Invoke(helper.ViewData.Model);
            if (string.IsNullOrWhiteSpace(text) || text.Length < maxLength)
                return text;

            return text.Substring(0, Math.Min(text.Length, maxLength)) + "...";
        }
    }
}