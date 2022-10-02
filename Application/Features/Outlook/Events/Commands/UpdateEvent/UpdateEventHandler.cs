using AutoMapper;
using ExternalServices.Outlook.Dtos;
using ExternalServices.Outlook.Interface;
using MediatR;

namespace Application.Features.Outlook.Events.Commands.UpdateEvent
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventRequest, UpdateEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        public UpdateEventHandler(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        public async Task<UpdateEventResponse> Handle(UpdateEventRequest request, CancellationToken cancellationToken)
        {
            var eventoDto = _mapper.Map<EventDto>(request.EventCalendar);
            await _eventService.UpdateEventAsync(eventoDto, request.AccessToken);
            return new UpdateEventResponse();
        }
    }
}
