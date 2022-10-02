using AutoMapper;
using ExternalServices.Outlook.Interface;
using MediatR;

namespace Application.Features.Outlook.Events.Commands.DeleteEvent
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventRequest, DeleteEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        public DeleteEventHandler(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        public async Task<DeleteEventResponse> Handle(DeleteEventRequest request, CancellationToken cancellationToken)
        {
            await _eventService.DeleteEventAsync(request.EventId, request.AccessToken);
            return new DeleteEventResponse();
        }
    }
}
