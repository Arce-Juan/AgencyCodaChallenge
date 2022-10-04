using ExternalServices.Outlook.Dtos;
using ExternalServices.Outlook.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ExternalServices.Outlook.Services
{
    public class EventService : IEventService
    {
        public async Task<IEnumerable<EventDto>> GetAllEventsAsync(string accessToken)
        {
            RestClient restClient = new RestClient("https://graph.microsoft.com/v1.0/me/calendar/events");
            RestRequest restRequest = new RestRequest();

            restRequest.AddHeader("Authorization", "Bearer " + accessToken);
            restRequest.AddHeader("Prefer", "outlook.timezone=\"SA Pacific Standard Time\"");
            restRequest.AddHeader("Prefer", "outlook.body-content-type=\"text\"");

            var response = await restClient.GetAsync(restRequest);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JObject eventsList = JObject.Parse(response.Content);
                var calendarEvents = eventsList["value"].ToObject<IEnumerable<EventDto>>();
                return calendarEvents;
            }

            return new List<EventDto>();
        }

        public async Task<EventDto> GetEventAsync(string idEvent, string accessToken)
        {
            RestClient restClient = new RestClient($"https://graph.microsoft.com/v1.0/me/calendar/events/{idEvent}");
            RestRequest restRequest = new RestRequest();

            restRequest.AddHeader("Authorization", "Bearer " + accessToken);
            restRequest.AddHeader("Prefer", "outlook.timezone=\"SA Pacific Standard Time\"");
            restRequest.AddHeader("Prefer", "outlook.body-content-type=\"text\"");

            var response = await restClient.GetAsync(restRequest);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var calendarEvent = JObject.Parse(response.Content).ToObject<EventDto>();
                return calendarEvent;
            }

            return null;
        }

        public async Task CreateEventAsync(EventDto eventDto, string accessToken)
        {
            try
            {
                RestClient restClient = new RestClient("https://graph.microsoft.com/v1.0/me/calendar/events");
                RestRequest restRequest = new RestRequest();

                restRequest.AddHeader("Authorization", "Bearer " + accessToken);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json", JsonConvert.SerializeObject(eventDto), ParameterType.RequestBody);

                await restClient.PostAsync(restRequest);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public async Task UpdateEventAsync(EventDto calendarEvent, string accessToken)
        {
            RestClient restClient = new RestClient($"https://graph.microsoft.com/v1.0/me/calendar/events/{calendarEvent.Id}");
            RestRequest restRequest = new RestRequest();

            restRequest.AddHeader("Authorization", "Bearer " + accessToken);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(calendarEvent), ParameterType.RequestBody);

            await restClient.PatchAsync(restRequest);
        }
        public async Task DeleteEventAsync(string eventId, string accessToken)
        {
            RestClient restClient = new RestClient($"https://graph.microsoft.com/v1.0/me/calendar/events/{eventId}");
            RestRequest restRequest = new RestRequest();

            restRequest.AddHeader("Authorization", "Bearer " + accessToken);

            await restClient.DeleteAsync(restRequest);
        }
    }
}
