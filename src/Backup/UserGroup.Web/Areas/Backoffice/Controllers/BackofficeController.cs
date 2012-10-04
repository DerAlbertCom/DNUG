using System.Web.Mvc;
using Aperea.ActionFilter;
using UserGroup.Web.Controllers;

namespace UserGroup.Web.Areas.Backoffice.Controllers
{
    [RequireSsl(Order = -1)]
    [Authorize(Roles = UserGroup.Security.Roles.Administrator, Order = 100)]
    public abstract class BackofficeController : BaseController
    {
    }
}