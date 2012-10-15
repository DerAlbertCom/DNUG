using System.Web.Mvc;
using Aperea.Identity;

namespace UserGroup.Web.Controllers
{
    public class MetadataController : BaseController
    {
        readonly IRelyingPartyMetadataGenerator _metadataGenerator;

        public MetadataController(IRelyingPartyMetadataGenerator metadataGenerator)
        {
            _metadataGenerator = metadataGenerator;
        }

        [OutputCache(Duration = 60*60)]
        public ActionResult Federation()
        {
            var metaData = _metadataGenerator.GenerateAsString();
            return Content(metaData, "text/xml");
        }
    }
}