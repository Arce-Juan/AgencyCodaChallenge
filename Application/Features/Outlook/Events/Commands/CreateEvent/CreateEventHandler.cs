using AutoMapper;
using ExternalServices.Outlook.Dtos;
using ExternalServices.Outlook.Interface;
using MediatR;

namespace Application.Features.Outlook.Events.Commands.CreateEvent
{
    public class CreateEventHandler : IRequestHandler<CreateEventRequest, CreateEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        public CreateEventHandler(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        public async Task<CreateEventResponse> Handle(CreateEventRequest request, CancellationToken cancellationToken)
        {
            var eventDto = _mapper.Map<EventDto>(request.EventCalendar);
            await _eventService.CreateEventAsync(eventDto, request.AccessToken);
            return new CreateEventResponse();
        }
    }
}
