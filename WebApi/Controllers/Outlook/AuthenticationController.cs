using Application.Features.Outlook.Authentications.Queries.GetContentToCallback;
using Application.Features.Outlook.Authentications.Queries.GetRedirectUrl;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Outlook
{
    [ApiVersion("1.0")]
    public class AuthenticationController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("RedirectUrl")]
        public async Task<IActionResult> RedirectUrl()
        {
            return Ok(await Mediator.Send(new GetRedirectUrlRequest()
            {
                IdClient = _configuration.GetValue<string>("AppSettings:Credentials:ClientId"),
                RedirectUrl = _configuration.GetValue<string>("AppSettings:Credentials:RedirectUrl"),
                Scope = _configuration.GetValue<string>("AppSettings:Credentials:Scope")
            }));
        }

        [HttpGet("Callback")]
        public async Task<IActionResult> Callback(string code)
        {
            return Ok(await Mediator.Send(new GetContentToCallbackRequest()
            {
                IdClient = _configuration.GetValue<string>("AppSettings:Credentials:ClientId"),
                ClientSecret = _configuration.GetValue<string>("AppSettings:Credentials:ClientSecret"),
                RedirectUrl = _configuration.GetValue<string>("AppSettings:Credentials:RedirectUrl"),
                Scope = _configuration.GetValue<string>("AppSettings:Credentials:Scope"),
                Code = code
            }));
        }
    }
}
