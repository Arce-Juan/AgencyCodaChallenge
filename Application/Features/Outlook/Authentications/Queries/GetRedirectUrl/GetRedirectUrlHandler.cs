using ExternalServices.Outlook.Interface;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Outlook.Authentications.Queries.GetRedirectUrl
{
    public class GetRedirectUrlHandler : IRequestHandler<GetRedirectUrlRequest, GetRedirectUrlResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public GetRedirectUrlHandler(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        public async Task<GetRedirectUrlResponse> Handle(GetRedirectUrlRequest request, CancellationToken cancellationToken)
        {
            return new GetRedirectUrlResponse()
            {
                RedirectUrl = _authenticationService.RedirectUrl(request.Scope, request.RedirectUrl, request.IdClient)
            };
        }
    }
}
