namespace MultiShop.IdentityServer.Utilities.Security.Jwt
{
    public class MyTokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Expire { get; set; }
        public string SecretKey { get; set; }
    }
}
