using Aperea.Commands;
using Machine.Specifications;
using Machine.Fakes;
using UserGroup.Commands;

namespace UserGroup.Core.Specs.Commands
{
    [Subject(typeof (ChangeTalkHandler))]
    public class When_changing_an_existing_talk_with_speakers : WithSubject<ChangeTalkHandler>
    {
        Establish context = () => {  };

        Because of = () => { };

        It should_ = () => { };
    }

    public class ChangeTalkHandler : CommandHandler<ChangeTalk>
    {
        public override void Execute(ChangeTalk command)
        {
            throw new System.NotImplementedException();
        }
    }
}