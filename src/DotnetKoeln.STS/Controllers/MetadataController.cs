using System.Web.Mvc;
using Aperea.Identity;

namespace DotnetKoeln.STS.Controllers
{
    public class MetadataController : BaseController
    {
        readonly IIdentityProviderMetadataGenerator generator;

        public MetadataController(IIdentityProviderMetadataGenerator generator)
        {
            this.generator = generator;
        }

        [OutputCache(Duration = 60*120)]
        public ActionResult Federation()
        {
            var metaData = generator.GenerateAsString();
            return Content(metaData, "text/xml");
        }
    }
}