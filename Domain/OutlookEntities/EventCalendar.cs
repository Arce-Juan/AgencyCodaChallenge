namespace Domain.OutlookEntities
{
    public class EventCalendar
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public EventCalendarBody Body { get; set; }
        public EventCalendarDate Start { get; set; }
        public EventCalendarDate End { get; set; }
    }
}
