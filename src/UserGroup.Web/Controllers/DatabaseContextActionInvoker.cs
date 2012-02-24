using System;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using UserGroup.Data;

namespace UserGroup.Web.Controllers
{
    /// <summary>
    /// Make sure that the Database Context is closed before the ActionResult is executed, this
    /// is to avoid LazyLoading in the ActionResult, a result should have all needed data collected by the action
    /// </summary>
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