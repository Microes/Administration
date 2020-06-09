using Administration.Domains.Conference.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Domains.Conference.Handlers
{
    public sealed class ConferenceCommandHandler : 
        IRequestHandler<CreateConferenceCommand>
    {
        public Task<Unit> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
