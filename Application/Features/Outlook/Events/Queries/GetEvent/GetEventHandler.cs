using AutoMapper;
using Domain.OutlookEntities;
using ExternalServices.Outlook.Interface;
using MediatR;

namespace Application.Features.Outlook.Events.Queries.GetEvent
{
    public class GetEventHandler : IRequestHandler<GetEventRequest, GetEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        public GetEventHandler(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        public async Task<GetEventResponse> Handle(GetEventRequest request, CancellationToken cancellationToken)
        {
            var eventCalendar = await _eventService.GetEventAsync(request.EventId, request.AccessToken);
            return new GetEventResponse()
            {
                EventCalendar = _mapper.Map<EventCalendar>(eventCalendar)
            };
        }
    }
}
