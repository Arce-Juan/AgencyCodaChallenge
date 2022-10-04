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
        public EventController()
        {
        }

        [HttpGet("AllEvents")]
        public async Task<IActionResult> AllEvents(string accessToken)
        {
            return Ok(await Mediator.Send(new GetAllEventsRequest()
            {
                AccessToken = accessToken
            }));
        }

        [HttpGet("GetEvent")]
        public async Task<IActionResult> GetEvent(string accessToken, string eventId)
        {
            return Ok(await Mediator.Send(new GetEventRequest()
            {
                EventId = eventId,
                AccessToken = accessToken
            }));
        }

        [HttpPost("CreateEvent")]
        public async Task<IActionResult> CreateEvent([FromQuery] string accessToken, [FromBody] EventCalendar calendarEvent)
        //public async Task<IActionResult> CreateEvent([FromBody] EventCalendar calendarEvent)
        {
            return Ok(await Mediator.Send(new CreateEventRequest()
            {
                AccessToken = accessToken,
                EventCalendar = calendarEvent
            }));
        }

        [HttpPut("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent([FromQuery] string accessToken, [FromQuery] string eventId, [FromBody] EventCalendar calendarEvent)
        {
            calendarEvent.Id = eventId;
            return Ok(await Mediator.Send(new UpdateEventRequest()
            {
                AccessToken = accessToken,
                EventCalendar = calendarEvent
            }));
        }

        [HttpDelete("DeleteEvent")]
        public async Task<IActionResult> DeleteEvent([FromQuery] string accessToken, [FromQuery] string eventId)
        {
            return Ok(await Mediator.Send(new DeleteEventRequest()
            {
                AccessToken = accessToken,
                EventId = eventId
            }));
        }
    }
}
