using System.Web.Mvc;
using DotnetKoeln.STS.ActionFilter;

namespace DotnetKoeln.STS.Controllers
{
    [RequireSsl]
    public class BaseController : Controller
    {
    }
}