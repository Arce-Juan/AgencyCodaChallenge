namespace WebSystem.Dtos
{
    public class EventCalendarDto
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public EventCalendarBodyDto Body { get; set; }
        public EventCalendarDate Start { get; set; }
        public EventCalendarDate End { get; set; }

        public EventCalendarDto()
        {
            this.Body = new EventCalendarBodyDto()
            {
                ContentType = "text"
            };
            this.Start = new EventCalendarDate()
            {
                TimeZone = "UTC"
            };
            this.End = new EventCalendarDate()
            {
                TimeZone = "UTC"
            };
        }
    }

    public class EventCalendarBodyDto
    {
        public string ContentType { get; set; }
        public string Content { get; set; }
    }

    public class EventCalendarDate
    {
        public string DateTime { get; set; }
        public string TimeZone { get; set; }
    }
}
