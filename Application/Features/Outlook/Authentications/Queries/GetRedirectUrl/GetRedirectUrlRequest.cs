using MediatR;

namespace Application.Features.Outlook.Authentications.Queries.GetRedirectUrl
{
    public class GetRedirectUrlRequest : IRequest<GetRedirectUrlResponse>
    {
        public string IdClient { get; set; }
        public string RedirectUrl { get; set; }
        public string Scope { get; set; }
    }
}
