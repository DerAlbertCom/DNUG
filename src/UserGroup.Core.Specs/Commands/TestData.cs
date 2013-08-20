using System;
using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    internal static class TestData
    {
        public static Meeting[] GetThreeMeetings()
        {
            var threeMeetings = new[]
            {
                new Meeting {Title = "Eins", Description = "EinsDesc", Slug = Guid.NewGuid().ToString(), Group = "dnugk"},
                new Meeting {Title = "Zwei", Description = "ZweiDesc", Slug = Guid.NewGuid().ToString(), Group = "dnugk"},
                new Meeting {Title = "Drei", Description = "DreiDesc", Slug = Guid.NewGuid().ToString(), Group = "dnugk"}
            };
            return threeMeetings;
        }

        public static Talk[] GetFiveTalks()
        {
            var threeTalks = new[]
            {
                new Talk
                {
                    Title = "EinsTalk",
                    Description = "EinsDescTalk",
                    Slug = Guid.NewGuid().ToString(),
                    Abstract = "AbstractEins"
                },
                new Talk
                {
                    Title = "ZweiTalk",
                    Description = "ZweiDescTalk",
                    Slug = Guid.NewGuid().ToString(),
                    Abstract = "AbstractZwei"
                },
                new Talk
                {
                    Title = "DreiTalk",
                    Description = "DreiDescTalk",
                    Slug = Guid.NewGuid().ToString(),
                    Abstract = "AbstractDrei"
                },
                new Talk
                {
                    Title = "VierTalk",
                    Description = "VierDescTalk",
                    Slug = Guid.NewGuid().ToString(),
                    Abstract = "AbstractVier"
                },
                new Talk
                {
                    Title = "FünfTalk",
                    Description = "FünfDescTalk",
                    Slug = Guid.NewGuid().ToString(),
                    Abstract = "AbstractFünf"
                }
            };
            return threeTalks;
        }

        public static Speaker[] GetFiveSpeakers()
        {
            var speakers = new[]
            {
                new Speaker {GivenName = "Albert", LastName = "Weinert", Slug = Guid.NewGuid().ToString()},
                new Speaker {GivenName = "Stefan", LastName = "Lange", Slug = Guid.NewGuid().ToString()},
                new Speaker {GivenName = "Roland", LastName = "Weigelt", Slug = Guid.NewGuid().ToString()},
                new Speaker {GivenName = "Meister", LastName = "Lampe", Slug = Guid.NewGuid().ToString()},
                new Speaker {GivenName = "Timo", LastName = "Beil", Slug = Guid.NewGuid().ToString()}
            };
            return speakers;
        }
    }
}