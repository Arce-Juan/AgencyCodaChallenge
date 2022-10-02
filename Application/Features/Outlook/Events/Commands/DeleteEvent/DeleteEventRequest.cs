using MediatR;

namespace Application.Features.Outlook.Events.Commands.DeleteEvent
{
    public class DeleteEventRequest : IRequest<DeleteEventResponse>
    {
        public string AccessToken { get; set; }
        public string EventId { get; set; }
    }
}
