using MediatR;

namespace Application.Features.Outlook.Authentications.Queries.GetContentToCallback
{
    public class GetContentToCallbackRequest : IRequest<GetContentToCallbackResponse>
    {
        public string IdClient { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrl { get; set; }
        public string Scope { get; set; }
        public string Code { get; set; }
    }
}
