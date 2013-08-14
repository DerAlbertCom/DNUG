using System;
using AutoMapper;
using Machine.Fakes;
using Machine.Specifications;

namespace UserGroup.Core.Specs
{
    [Subject("UserGroup.Core.Mapping")]
    public class When_checking_the_mappings : WithFakes
    {
        Establish context = () => With<BehaviorCoreMapping>();

        Because of = () => exception = Catch.Exception(Mapper.AssertConfigurationIsValid);         

        It should_not_throw_an_exception = ()=> exception.ShouldBeNull();

        static Exception exception;
    }
}