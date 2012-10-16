namespace UserGroup.Web.Areas.Backoffice.Models
{
    public class DisplaySpeakerLineModel
    {
        public int Id { get; set; }
        public string GivenName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return GivenName + " " + LastName; } }

    }
}