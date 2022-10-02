using Domain.OutlookEntities;

namespace Application.Features.Outlook.Events.Queries.GetAllEvents
{
    public class GetAllEventsResponse
    {
        public IEnumerable<EventCalendar> Events { get; set; }
    }
}
