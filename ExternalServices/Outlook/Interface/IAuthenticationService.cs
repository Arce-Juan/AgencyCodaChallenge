namespace ExternalServices.Outlook.Interface
{
    public interface IAuthenticationService
    {
        string RedirectUrl(string scope, string redirectUrl, string idClient);
        Task<string> CallbackAsync(string idClient, string scope, string redirectUrl, string code, string clientSecret);
    }
}
