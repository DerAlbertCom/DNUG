using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace UserGroup.Web.Extensions
{
    public static class InputExtensions
    {
        public static MvcHtmlString LabelAndEditorFor<T>(this HtmlHelper<T> helper,
                                                         Expression<Func<T, object>> expression)
        {
            return new MvcHtmlString(string.Format("{0} {1} {2}",
                                                   helper.LabelFor(expression),
                                                   helper.EditorFor(expression),
                                                   helper.ValidationMessageFor(expression)
                                         ));
        }
    }
}