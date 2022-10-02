using Domain.OutlookEntities;
using MediatR;

namespace Application.Features.Outlook.Events.Commands.CreateEvent
{
    public class CreateEventRequest : IRequest<CreateEventResponse>
    {
        public string AccessToken { get; set; }
        public EventCalendar EventCalendar { get; set; }
    }
}
