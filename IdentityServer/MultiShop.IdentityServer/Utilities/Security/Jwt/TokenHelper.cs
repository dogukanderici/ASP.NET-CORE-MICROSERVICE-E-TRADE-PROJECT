using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Utilities.Security.Encryption;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MultiShop.IdentityServer.Utilities.Security.Jwt
{
    public class TokenHelper : ITokenHelper
    {
        private readonly IConfiguration _configuration;
        private MyTokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<MyTokenOptions>();
        }

        public AccessToken CreateAccessToken(GetUserViewModel getUserViewModel)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.Expire);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecretKey);
            var signingCredentials = SigningCredentailHelper.CreateSigningCredentials(securityKey);

            // Claim için bir extension yazılabilir.
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(getUserViewModel.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, getUserViewModel.Role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, getUserViewModel.Id));

            if (!string.IsNullOrEmpty(getUserViewModel.Username))
            {
                claims.Add(new Claim("Username", getUserViewModel.Username));
            }

            var jwt = CreateJwtSecurityToken(_tokenOptions, getUserViewModel, signingCredentials, claims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(MyTokenOptions tokenOptions, GetUserViewModel getUserViewMode, SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: claims
                );

            return jwt;
       }
    }
}
