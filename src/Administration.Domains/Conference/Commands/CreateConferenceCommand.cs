using MediatR;

namespace Administration.Domains.Conference.Commands
{
    public sealed class CreateConferenceCommand : IRequest
    {
        public string Name { get; private set; }

        public CreateConferenceCommand(
            string name
            )
        {
            Name = name;
        }
    }
}
