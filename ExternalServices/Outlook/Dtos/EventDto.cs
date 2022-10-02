namespace ExternalServices.Outlook.Dtos
{
    public class EventDto
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public EventBodyDto Body { get; set; }
        public EventDateDto Start { get; set; }
        public EventDateDto End { get; set; }
    }
}
