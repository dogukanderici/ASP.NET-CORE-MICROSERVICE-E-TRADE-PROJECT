using Microsoft.Identity.Client;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateAccessToken(GetUserViewModel getUserViewModel);
    }
}
