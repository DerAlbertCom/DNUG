using System;
using System.Linq;
using AutoMapper;
using Machine.Fakes;
using Microsoft.Practices.ServiceLocation;
using UserGroup.Infrastructure.Mappings;

namespace UserGroup.Core.Specs
{
    internal class BehaviorCoreMapping
    {
        OnEstablish context = accessor =>
        {
            var types = from t in typeof (MeetingMappings).Assembly.GetExportedTypes()
                where typeof (Profile).IsAssignableFrom(t)
                select t;

            Mapper.Initialize(c =>
            {
                foreach (var type in types)
                {
                    c.AddProfile((Profile) Activator.CreateInstance(type));
                }
            });
        };

        OnCleanup subject = subject => Mapper.Reset();
    }
}