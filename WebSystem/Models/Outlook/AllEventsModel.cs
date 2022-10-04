using WebSystem.Dtos;

namespace WebSystem.Models.Outlook
{
    public class AllEventsModel
    {
        public string AccessToken { get; set; }
        public List<EventCalendarDto> EventCalendar { get; set; }
    }
}
