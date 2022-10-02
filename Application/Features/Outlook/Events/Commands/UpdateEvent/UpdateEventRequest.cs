using Domain.OutlookEntities;
using MediatR;

namespace Application.Features.Outlook.Events.Commands.UpdateEvent
{
    public class UpdateEventRequest : IRequest<UpdateEventResponse>
    {
        public string AccessToken { get; set; }
        public EventCalendar EventCalendar { get; set; }
    }
}
