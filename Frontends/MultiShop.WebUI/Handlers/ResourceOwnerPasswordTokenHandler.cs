
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.Concrete;
using System.Net;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Handlers
{
    public class ResourceOwnerPasswordTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IIdentityService _identityService;

        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor httpContextAccessor, IIdentityService identityService)
        {
            _httpContextAccessor = httpContextAccessor;
            _identityService = identityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Kullanıcının sistemdeki access token'ını alır ve Header'a yazar.
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await base.SendAsync(request, cancellationToken);

            // İstek sonucu Unauthorize dönerse Refresh token üretip tekrar header'a yazar.
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var tokenResponse = await _identityService.GetRefreshToken();
                if (tokenResponse != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
                else
                {
                    // Login ekranına yönlendirme
                }
            }

            if(response.StatusCode==HttpStatusCode.InternalServerError)
            {
                throw new Exception("Beklenmedik Hata! Kod:500-InternalServerError");
            }

            return response;
        }
    }
}
