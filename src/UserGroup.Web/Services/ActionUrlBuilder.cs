using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UserGroup.Web.Services
{
    public class ActionUrlBuilder : IActionUrlBuilder
    {
        readonly HttpContextBase _httpContext;
        readonly HttpRequestBase _httpRequest;

        public ActionUrlBuilder(HttpContextBase httpContext, HttpRequestBase httpRequest)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");
            if (httpRequest == null) throw new ArgumentNullException("httpRequest");
            _httpContext = httpContext;
            _httpRequest = httpRequest;
        }

        public string GetActionUrl(string action, string controller)
        {
            return GetActionUrl(action, controller, null);
        }

        public string GetActionUrl(string action, string controller, object routeValues)
        {
            return string.Format("{0}{1}",
                GetBaseUrl(),
                GetUrlHelper().Action(action, controller, routeValues));
        }

        UrlHelper GetUrlHelper()
        {
            return new UrlHelper(CreateRequestContext());
        }

        string GetBaseUrl()
        {
            return string.Format("{0}://{1}", _httpRequest.Url.Scheme, _httpRequest.Url.Authority);
        }

        RequestContext CreateRequestContext()
        {
            return new RequestContext(_httpContext, RouteTable.Routes.GetRouteData(_httpContext));
        }
    }
}