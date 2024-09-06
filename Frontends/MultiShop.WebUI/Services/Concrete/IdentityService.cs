using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.Dtos.IdentityDtos;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Settings;
using System.Security.Claims;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            // IdentityServer'dan gerekli yetkilendirme ve kimlik doğrulama endpoint'lerini alır.
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                // IdentityServer Url'i ve https zorunluluğunu belirleyen istek nesnesi
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            // Kullanıcının açık oturumundaki refresh token'ını alır.
            var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            // IdentityServer'a yeni bir refresh token almak için istek nesnesi oluşturur.
            RefreshTokenRequest refreshTokenRequest = new RefreshTokenRequest()
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                RefreshToken = refreshToken,
                Address = discoveryEndPoint.TokenEndpoint
            };

            // IdentityServer'dan yeni bir access token ve refresh token alır.
            var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

            // Alınan access token ve refresh token'ın tarayıcıda nasıl tutulacağını belirten AuthenticationToken nesnesi oluşturulur.
            var authenticationToken = new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value=token.AccessToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.RefreshToken,
                    Value=token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value=DateTime.Now.AddMinutes(token.ExpiresIn).ToString()
                }
            };

            // Kullanıcının mevcut oturumunun doğrulaması yapılır.
            var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();

            // Yeni alınan token'ların kullanıcı oturum özelliklerine kaydedilmesini sağlar.
            var properties = result.Properties;
            properties.StoreTokens(authenticationToken);

            // Güncellenmiş token'larla kullanıcıyı yeniden oturum açmış olarak belirtir.
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

            return true;
        }

        public async Task<bool> SignIn(SignInDto signUpDto)
        {
            // IdentityServer'dan gerekli yetkilendirme ve kimlik doğrulama endpoint'lerini alır.
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                // IdentityServer Url'i ve https zorunluluğunu belirleyen istek nesnesi
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            // IdentityServer'a gönderilecek token isteği oluşturur.
            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                UserName = signUpDto.Username,
                Password = signUpDto.Password,
                Address = discoveryEndPoint.TokenEndpoint
            };

            // IdentityServer'a istek gönderir ve bir token değeri döner.
            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            // userinfo endpoint'ine istek göndermek için bir istek oluşturur.
            var userInfoRequest = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint
            };

            // Token kullanılarak kullanıcının detaylı bilgilerini almak için IdentityServer'ın userinfo endpoint'ine istek gönderir.
            var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

            // Kullanıcının bilgileri ( userValues.Claims ), yetkilerini ve rollerini tarayıcıda cookie'de saklamak içn ClaimIdentity nesnesine dönüştürülür.
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            // Yukarıda oluşturulan claimsIdentity kullanılarak kullanıcı kimliğini temsil eden ClaimsPrincipal nesnesine tarayıcıda cookie'de saklamak için dönüştürülür.
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            // Token'ların tarayıcıda nasıl saklanacağını belirlemek için kullanılan AuthenticationToken nesnesi oluşturur.
            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value=token.AccessToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.RefreshToken,
                    Value=token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value=DateTime.Now.AddMinutes(token.ExpiresIn).ToString()
                }
            });

            // false değeri tarayıcı kapatılsa bile token'ların tarayıcıda saklanmamasını sağlar.
            authenticationProperties.IsPersistent = false;

            // claimsPrincipal ve authenticationProperties kullanılarak tarayıcıda cookie oluştururak kullanıcının oturum açmasını sağlar.
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

            return true;
        }
    }
}
