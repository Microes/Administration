using Administration.Domains.Conference.Commands;

namespace Administration.Api.Dtoes
{
    public class CreateConferenceCommandDto
    {
        public string Name { get; set; }

        public CreateConferenceCommand ToDomainCommand()
        {
            return new CreateConferenceCommand(Name);
        }
    }
}
