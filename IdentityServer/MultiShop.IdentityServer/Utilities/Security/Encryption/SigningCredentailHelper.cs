using Microsoft.IdentityModel.Tokens;

namespace MultiShop.IdentityServer.Utilities.Security.Encryption
{
    public class SigningCredentailHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
