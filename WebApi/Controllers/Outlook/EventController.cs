using Application.Features.Outlook.Events.Commands.CreateEvent;
using Application.Features.Outlook.Events.Commands.DeleteEvent;
using Application.Features.Outlook.Events.Commands.UpdateEvent;
using Application.Features.Outlook.Events.Queries.GetAllEvents;
using Application.Features.Outlook.Events.Queries.GetEvent;
using Domain.OutlookEntities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Outlook
{
    [ApiVersion("1.0")]
    public class EventController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        public EventController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("AllEvents/{accessToken}")]
        public async Task<IActionResult> AllEvents([FromRoute] string accessToken)
        {
            return Ok(await Mediator.Send(new GetAllEventsRequest()
            {
                AccessToken = accessToken
            }));
        }

        [HttpGet("GetEvent/{eventId}/{accessToken}")]
        public async Task<IActionResult> GetEvent([FromRoute] string eventId, [FromRoute] string accessToken)
        {
            return Ok(await Mediator.Send(new GetEventRequest()
            {
                EventId = eventId,
                AccessToken = accessToken
            }));
        }

        [HttpPost("CreateEvent/{accessToken}")]
        public async Task<IActionResult> CreateEvent([FromRoute] string accessToken, [FromBody] EventCalendar calendarEvent)
        {
            return Ok(await Mediator.Send(new CreateEventRequest()
            {
                AccessToken = accessToken,
                EventCalendar = calendarEvent
            }));
        }

        [HttpPut("UpdateEvent/{eventId}/{accessToken}")]
        public async Task<IActionResult> UpdateEvent([FromRoute] string eventId, [FromRoute] string accessToken, [FromBody] EventCalendar calendarEvent)
        {
            calendarEvent.Id = eventId;
            return Ok(await Mediator.Send(new UpdateEventRequest()
            {
                AccessToken = accessToken,
                EventCalendar = calendarEvent
            }));
        }

        [HttpDelete("DeleteEvent/{eventId}/{accessToken}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] string eventId, [FromRoute] string accessToken)
        {
            return Ok(await Mediator.Send(new DeleteEventRequest()
            {
                AccessToken = accessToken,
                EventId = eventId
            }));
        }
    }
}
