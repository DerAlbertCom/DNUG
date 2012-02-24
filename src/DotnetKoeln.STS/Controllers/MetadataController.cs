using System.Text;
using System.Web.Mvc;
using DotnetKoeln.STS.Services;

namespace DotnetKoeln.STS.Controllers
{
    public class MetadataController : BaseController
    {
        readonly IMetadataGenerator generator;

        public MetadataController(IMetadataGenerator generator)
        {
            this.generator = generator;
        }

        public ActionResult Federation()
        {
            var metaData = generator.GenerateAsString();
            return Content(metaData, "text/xml");
        }
    }
}