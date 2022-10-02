using ExternalServices.Outlook.Interface;
using MediatR;

namespace Application.Features.Outlook.Authentications.Queries.GetContentToCallback
{
    public class GetContentToCallbackHandler : IRequestHandler<GetContentToCallbackRequest, GetContentToCallbackResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public GetContentToCallbackHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<GetContentToCallbackResponse> Handle(GetContentToCallbackRequest request, CancellationToken cancellationToken)
        {
            return new GetContentToCallbackResponse()
            {
                Content = await _authenticationService.CallbackAsync(request.IdClient, request.Scope, request.RedirectUrl, request.Code, request.ClientSecret)
            };
        }
    }
}
