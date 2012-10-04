namespace UserGroup.Web.Models
{
    public class SpeakerLineModel
    {
        public string GivenName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return GivenName + " " + LastName; } }

        public string SpeakerUrl { get; set; }
    }
}