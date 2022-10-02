using ExternalServices.Outlook.Interface;
using RestSharp;
using System.Net;

namespace ExternalServices.Outlook.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public string RedirectUrl(string scope, string redirectUrl, string idClient)
        {
            string responseRedirectUrl = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?" +
                                 "&scope=" + scope +
                                 "&response_type=code" +
                                 "&response_mode=query" +
                                 "&state=themessydeveloper" +
                                 "&redirect_uri=" + redirectUrl +
                                 "&client_id=" + idClient;
            return responseRedirectUrl;
        }

        public async Task<string> CallbackAsync(string idClient, string scope, string redirectUrl, string code, string clientSecret)
        {
            RestClient restClient = new RestClient("https://login.microsoftonline.com/common/oauth2/v2.0/token");
            RestRequest restRequest = new RestRequest();

            restRequest.AddParameter("client_id", idClient);
            restRequest.AddParameter("scope", scope);
            restRequest.AddParameter("redirect_uri", redirectUrl);
            restRequest.AddParameter("code", code);
            restRequest.AddParameter("grant_type", "authorization_code");
            restRequest.AddParameter("client_secret", clientSecret);

            var response = await restClient.PostAsync(restRequest);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Content;
            }
            else
            {
                return "Error in CallbackAsync";
            }
        }
    }
}
