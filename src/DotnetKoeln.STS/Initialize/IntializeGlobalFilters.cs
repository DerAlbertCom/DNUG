using System.Web.Mvc;
using Aperea.Infrastructure.Bootstrap;
using DotnetKoeln.STS.ActionFilter;

namespace DotnetKoeln.STS.Initialize
{
    public class IntializeGlobalFilters : BootstrapItem
    {
        public override void Execute()
        {
            RegisterFilters(GlobalFilters.Filters);
        }

        void RegisterFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ValidateAntiForgeryTokenFilter(), -1);
        }
    }
}