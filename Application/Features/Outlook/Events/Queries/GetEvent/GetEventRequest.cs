using MediatR;

namespace Application.Features.Outlook.Events.Queries.GetEvent
{
    public class GetEventRequest : IRequest<GetEventResponse>
    {
        public string AccessToken { get; set; }
        public string EventId { get; set; }
    }
}
