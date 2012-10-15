using System;
using System.Web.Mvc;
using StructureMap;

namespace UserGroup.Web.Infrastructure.IoC
{
    public class StructureMapViewPageActivator : IViewPageActivator
    {
        public object Create(ControllerContext controllerContext, Type type)
        {
            var viewPage = Activator.CreateInstance(type);
            ObjectFactory.Container.BuildUp(viewPage);
            return viewPage;
        }
    }
}