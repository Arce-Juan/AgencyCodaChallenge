using WebSystem.Dtos;

namespace WebSystem.Models.Outlook
{
    public class ABMEventModel
    {
        public string AccessToken { get; set; }
        public EventCalendarDto EventCalendar { get; set; }
        public string ErrorMessage { get; set; }
    }
}
