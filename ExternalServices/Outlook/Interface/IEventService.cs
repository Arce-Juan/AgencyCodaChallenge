using ExternalServices.Outlook.Dtos;

namespace ExternalServices.Outlook.Interface
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllEventsAsync(string access_token);
        Task<EventDto> GetEventAsync(string eventId, string access_token);
        Task CreateEventAsync(EventDto calendarEvent, string access_token);
        Task UpdateEventAsync(EventDto calendarEvent, string access_token);
        Task DeleteEventAsync(string eventId, string access_token);
    }
}
