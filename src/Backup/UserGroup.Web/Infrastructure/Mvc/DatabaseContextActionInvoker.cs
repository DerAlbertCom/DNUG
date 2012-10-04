using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using UserGroup.Data;

namespace UserGroup.Web.Infrastructure.Mvc
{
    public class DatabaseContextActionInvoker : ControllerActionInvoker
    {
        readonly IDatabaseContext databaseContext;


        public DatabaseContextActionInvoker(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public DatabaseContextActionInvoker()
            : this(ServiceLocator.Current.GetInstance<IDatabaseContext>())
        {
        }

        protected override void InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
        {
            databaseContext.Dispose();
            base.InvokeActionResult(controllerContext, actionResult);
        }
    }
}