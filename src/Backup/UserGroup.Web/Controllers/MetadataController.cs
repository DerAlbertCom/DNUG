using System.Web.Mvc;
using Aperea.Identity;

namespace UserGroup.Web.Controllers
{
    public class MetadataController : BaseController
    {
        readonly IRelyingPartyMetadataGenerator metadataGenerator;

        public MetadataController(IRelyingPartyMetadataGenerator metadataGenerator)
        {
            this.metadataGenerator = metadataGenerator;
        }

        [OutputCache(Duration = 60*60)]
        public ActionResult Federation()
        {
            var metaData = metadataGenerator.GenerateAsString();
            return Content(metaData, "text/xml");
        }
    }
}