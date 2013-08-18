using Machine.Fakes;
using UserGroup.Entities;
using UserGroup.Services;

namespace UserGroup.Core.Specs
{
    public class BehaviorSlugGenerators
    {
        OnEstablish context = accessor =>
        {
            var slugger = new Slugger();
            accessor.Configure<ISlugGenerator<Speaker>>(new SpeakerSlugGenerator(slugger));
            accessor.Configure<ISlugGenerator<Talk>>(new TalkSlugGenerator(slugger));
            accessor.Configure<ISlugGenerator<Meeting>>(new MeetingSlugGenerator(slugger));
            accessor.Configure<ISlugGenerator<Location>>(new LocationSlugGenerator(slugger));
        };
    }
}