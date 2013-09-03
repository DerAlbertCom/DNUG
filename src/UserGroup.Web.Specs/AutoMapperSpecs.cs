using System;
using System.Linq;
using AutoMapper;
using Machine.Specifications;
using UserGroup.Web.Mappings;

namespace UserGroup.Web.Specs
{
    [Subject(typeof (Mapper))]
    public class When_testing_the_mappings_for_automapper
    {
        Establish context = () =>
            {
                var profiles =
                            from t in typeof(MeetingProfile).Assembly.GetExportedTypes()
                            where typeof (Profile).IsAssignableFrom(t)
                            select t;
                foreach (var profile in profiles)
                {
                    Mapper.AddProfile((Profile) Activator.CreateInstance(profile));
                }
            };
        
        It should_the_have_a_validate_configuration = () => Mapper.AssertConfigurationIsValid();
    }
}