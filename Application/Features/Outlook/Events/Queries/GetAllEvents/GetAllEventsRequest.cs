using MediatR;

namespace Application.Features.Outlook.Events.Queries.GetAllEvents
{
    public class GetAllEventsRequest : IRequest<GetAllEventsResponse>
    {
        public string AccessToken { get; set; }
    }
}
