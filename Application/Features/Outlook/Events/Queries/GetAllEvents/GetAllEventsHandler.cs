using AutoMapper;
using Domain.OutlookEntities;
using ExternalServices.Outlook.Dtos;
using ExternalServices.Outlook.Interface;
using MediatR;

namespace Application.Features.Outlook.Events.Queries.GetAllEvents
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsRequest, GetAllEventsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        public GetAllEventsHandler(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        public async Task<GetAllEventsResponse> Handle(GetAllEventsRequest request, CancellationToken cancellationToken)
        {
            var events = await _eventService.GetAllEventsAsync(request.AccessToken);
            return new GetAllEventsResponse()
            {
                Events = _mapper.Map<IEnumerable<EventCalendar>>(events)
            };
        }
    }
}
