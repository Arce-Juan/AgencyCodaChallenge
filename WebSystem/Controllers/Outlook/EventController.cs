using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
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
                //var events = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EventCalendarDto>>(response.Content);
            }

            var model = new AllEventsModel()
            {
                AccessToken = accessToken,
                EventCalendar = events
            };

            return View(model);
        }
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
        public ActionResult Create(string accessToken)
        {
            var model = new ABMEventModel()
            {
                AccessToken = accessToken
            };

            return View(model);
        }

        //[HttpPost("CreateEvent")]
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

        public ActionResult Update(string accessToken)
        {
            var model = new ABMEventModel()
            {
                AccessToken = accessToken
            };

            return View(model);
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
    }
}
