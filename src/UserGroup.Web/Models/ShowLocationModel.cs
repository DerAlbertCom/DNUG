using UserGroup.Entities;

namespace UserGroup.Web.Models
{
    public class ShowLocationModel
    {
        public ShowLocationModel()
        {
            Address = new Address();
        }

        public string Name { get; set; }

        public Address Address { get; set; }

        public string Description { get; set; }
        public string MapsUrl { get; set; }

    }
}