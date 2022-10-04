using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Globalization;
using System.Net;
using System.Text.Json;
using WebSystem.Dtos;
using WebSystem.Models.Outlook;

namespace WebSystem.Controllers.Outlook
{
    public class EventController : Controller
    {
        //[HttpGet]
        public ActionResult Index(string accessToken)
        {
            RestClient restClient = new RestClient($"https://localhost:5001/api/v1/Event/AllEvents");
            RestRequest restRequest = new RestRequest();
            restRequest.AddParameter("accessToken", accessToken);

            var response = restClient.Get(restRequest);
            var events = new List<EventCalendarDto>();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var eventsJson = JObject.Parse(response.Content)["events"];
                var eventsJsonString = JsonConvert.SerializeObject(eventsJson);

                events = JsonConvert.DeserializeObject<List<EventCalendarDto>>(eventsJsonString);
            }

            var model = new AllEventsModel()
            {
                AccessToken = accessToken,
                EventCalendar = events
            };

            return View(model);
        }
        
        public ActionResult Create(string accessToken)
        {
            var model = new ABMEventModel()
            {
                AccessToken = accessToken
            };

            return View(model);
        }

        public ActionResult CreateEvent(IFormCollection collection)
        {
            try
            {
                string accessToken = collection["nHiddenToken"];
                string subject = collection["nInputTitulo"];
                string content = collection["nInputDetalles"];
                string startDate = collection["nInputInicia"];
                string endDate = collection["nInputFinaliza"];

                RestClient client = new RestClient("https://localhost:5001/api/v1/");
                RestRequest request = new RestRequest("Event/CreateEvent/", Method.Post);
                request.AddHeader("content-type", "application/json");
                request.AddQueryParameter("accessToken", accessToken);

                var body = new
                {
                    Id = "",
                    Subject = subject,
                    Body = new
                    {
                        ContentType = "text",
                        Content = content
                    },
                    Start = new
                    {
                        DateTime = startDate,
                        TimeZone = "UTC"
                    },
                    End = new
                    {
                        DateTime = endDate,
                        TimeZone = "UTC"
                    }
                };
                request.AddJsonBody(body);

                var response = client.PostAsync(request).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Event", new { accessToken = accessToken });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ActionResult Update(string idEvent, string accessToken)
        {
            RestClient restClient = new RestClient($"https://localhost:5001/api/v1/Event/GetEvent");
            RestRequest restRequest = new RestRequest();
            restRequest.AddParameter("accessToken", accessToken);
            restRequest.AddParameter("eventId", idEvent);

            var response = restClient.Get(restRequest);
            
            var eventCalendar = new EventCalendarDto();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var eventsJson = JObject.Parse(response.Content)["eventCalendar"];
                var eventJsonString = JsonConvert.SerializeObject(eventsJson);
                eventCalendar = JsonConvert.DeserializeObject<EventCalendarDto>(eventJsonString);

                string[] validformats = new string[] { "dd/MM/yyyy HH:mm:ss" };
                CultureInfo provider = new CultureInfo("en-US");

                var startDate = DateTime.ParseExact(eventCalendar.Start.DateTime, validformats, provider);
                var endDate = DateTime.ParseExact(eventCalendar.End.DateTime, validformats, provider);

                eventCalendar.Start.DateTime = startDate.ToString("yyyy-MM-dd hh:mm");
                eventCalendar.End.DateTime = endDate.ToString("yyyy-MM-dd hh:mm");
            }

            var model = new ABMEventModel()
            {
                AccessToken = accessToken,
                EventCalendar = eventCalendar
            };

            return View(model);
        }

        public ActionResult UpdateEvent(IFormCollection collection)
        {
            try
            {
                string accessToken = collection["nHiddenToken"];
                string eventId = collection["nInputEvent"];
                string subject = collection["nInputTitulo"];
                string content = collection["nInputDetalles"];
                string startDate = collection["nInputInicia"];
                string endDate = collection["nInputFinaliza"];

                RestClient client = new RestClient("https://localhost:5001/api/v1/");
                RestRequest request = new RestRequest("Event/UpdateEvent/", Method.Put);
                request.AddHeader("content-type", "application/json");
                request.AddQueryParameter("accessToken", accessToken);
                request.AddQueryParameter("eventId", eventId);

                var body = new
                {
                    Id = "",
                    Subject = subject,
                    Body = new
                    {
                        ContentType = "text",
                        Content = content
                    },
                    Start = new
                    {
                        DateTime = startDate,
                        TimeZone = "UTC"
                    },
                    End = new
                    {
                        DateTime = endDate,
                        TimeZone = "UTC"
                    }
                };
                request.AddJsonBody(body);

                var response = client.PutAsync(request).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Event", new { accessToken = accessToken });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ActionResult DeleteEvent(IFormCollection collection)
        {
            try
            {
                string accessToken = collection["nHiddenTokenEliminar"];
                string idEvent = collection["nEventToDelete"];

                RestClient client = new RestClient("https://localhost:5001/api/v1/");
                RestRequest request = new RestRequest("Event/DeleteEvent/", Method.Delete);
                request.AddHeader("content-type", "application/json");
                request.AddQueryParameter("accessToken", accessToken);
                request.AddQueryParameter("eventId", idEvent);

                var response = client.DeleteAsync(request).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Event", new { accessToken = accessToken });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        [HttpGet("CreateEvent")]
        public ActionResult CreateEvent([FromBody]EventCalendarDto calendarEvent)
        {
            string accessToken = "asdasdasdasdasd";
            RestClient restClient = new RestClient($"https://localhost:5001/api/v1/Event/CreateEvent");
            RestRequest restRequest = new RestRequest();
            restRequest.AddParameter("accessToken", "1234");
            //restRequest.AddParameter("calendarEvent", JsonSerializer.Serialize(eventDto));

            var response = restClient.Post(restRequest);

            return Ok(response);
        }
        */

        /*
        [HttpGet("GetAllEvents")]
        public ActionResult GetAllEvents(string accessToken)
        {
            RestClient restClient = new RestClient($"https://localhost:5001/api/v1/Event/AllEvents");
            RestRequest restRequest = new RestRequest();
            restRequest.AddParameter("accessToken", accessToken);

            var response = restClient.Get(restRequest); 

            return Ok(response);
        }
        */
        //[HttpGet("Create")]
    }
}
