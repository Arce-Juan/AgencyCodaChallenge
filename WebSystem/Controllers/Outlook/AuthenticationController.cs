﻿using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using WebSystem.Models.Outlook;

namespace WebSystem.Controllers.Outlook
{
    [ApiController]
    [Route("[controller]")]

    public class AuthenticationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new AuthenticationModel();
            return View(model);
        }

        [HttpGet("LoginUser")]
        public ActionResult LoginUser()
        {
            RestClient restClient = new RestClient($"https://localhost:5001/api/v1/Authentication/RedirectUrl");
            RestRequest restRequest = new RestRequest();

            var response = restClient.Get(restRequest);

            return Ok(response);
        }

        [HttpGet("LoginSuccess")]
        public ActionResult LoginSuccess(string code, string state)
        {
            var model = new LoginSuccessModel()
            {
                Code = code,
                State = state
            };

            return View(model);
        }

        [HttpGet("Callback")]
        public ActionResult Callback(string CodeAuth)
        {
            RestClient restClient = new RestClient($"https://localhost:5001/api/v1/Authentication/Callback");
            RestRequest restRequest = new RestRequest();
            restRequest.AddParameter("code", CodeAuth);

            var response = restClient.Get(restRequest);

            return Ok(response);
        }

    }
}
