using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    internal static class TestData
    {
        public static Meeting[] GetThreeMeetings()
        {
            var threeMeetings = new[]
            {
                new Meeting {Title = "Eins", Description = "EinsDesc", Slug = "eins"},
                new Meeting {Title = "Zwei", Description = "ZweiDesc", Slug = "zwei"},
                new Meeting {Title = "Drei", Description = "DreiDesc", Slug = "drei"}
            };
            EntityData.SetEntityIds(threeMeetings);
            return threeMeetings;
        }

        public static Talk[] GetThreeTalks()
        {
            var threeTalks = new[]
            {
                new Talk {Title = "EinsTalk", Description = "EinsDescTalk", Slug = "einstalk"},
                new Talk {Title = "ZweiTalk", Description = "ZweiDescTalk", Slug = "zweitalk"},
                new Talk {Title = "DreiTalk", Description = "DreiDescTalk", Slug = "dreitalk"}
            };
            EntityData.SetEntityIds(threeTalks);
            return threeTalks;
        }

        public static Speaker[] GetFiveSpeakers()
        {
            var speakers = new[]
            {
                new Speaker {GivenName = "Albert", LastName = "Weinert", Slug = "albert-weinert"},
                new Speaker {GivenName = "Stefan", LastName = "Lange", Slug = "stefan-lange"},
                new Speaker {GivenName = "Roland", LastName = "Weigelt", Slug = "roland-weigelt"},
                new Speaker {GivenName = "Meister", LastName = "Lampe", Slug = "meister-lampe"},
                new Speaker {GivenName = "Timo", LastName = "Beil", Slug = "timo-beil"}
            };
            EntityData.SetEntityIds(speakers);
            return speakers;
        }
    }
}