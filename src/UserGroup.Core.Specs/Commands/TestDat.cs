using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    internal static class TestData
    {
        public static Meeting[] GetThreeMeetings()
        {
            var threeMeetings = new[]
            {
                new Meeting {Title = "Eins", Description = "EinsDesc"},
                new Meeting {Title = "Zwei", Description = "ZweiDesc"},
                new Meeting {Title = "Drei", Description = "DreiDesc"}
            };
            EntityData.SetEntityIds(threeMeetings);
            return threeMeetings;
        }

        public static Talk[] GetThreeTalks()
        {
            var threeTalks = new[]
            {
                new Talk {Title = "EinsTalk", Description = "EinsDescTalk"},
                new Talk {Title = "ZweiTalk", Description = "ZweiDescTalk"},
                new Talk {Title = "DreiTalk", Description = "DreiDescTalk"}
            };
            EntityData.SetEntityIds(threeTalks);
            return threeTalks;
        }
    }
}