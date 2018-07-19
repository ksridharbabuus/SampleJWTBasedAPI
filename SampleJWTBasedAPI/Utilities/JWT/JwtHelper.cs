using System;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.ServiceModel.Security.Tokens;
using Microsoft.IdentityModel.Tokens;
using SampleJWTBasedAPI.Models.Jwt;
using SampleJWTBasedAPI.Utilities.Interfaces;

namespace SampleJWTBasedAPI.Utilities
{
    public class JwtHelper : IJwtHelper
    {
        public IJwtHelperConfiguration JwtHelperConfiguration => _jwtHelperConfiguration;
        private readonly IJwtHelperConfiguration _jwtHelperConfiguration;
        private readonly ISignatureProvider _signatureProvider;

        public JwtHelper(IJwtHelperConfiguration jwtHelperConfiguration, ISignatureProvider signatureProvider)
        {
            if (jwtHelperConfiguration == null || signatureProvider == null)
                throw new ArgumentNullException("Arguments can not be null");

            _jwtHelperConfiguration = jwtHelperConfiguration;
            _signatureProvider = signatureProvider;
        }
        public JwtTokenModel CreateJwtToken(IEnumerable<Claim> claims)
        {
            JsonExtensions.Serializer = JsonConvert.SerializeObject;
            JsonExtensions.Deserializer = JsonConvert.DeserializeObject;
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var subject = new ClaimsIdentity();
            foreach (var claim in claims)
            {
                subject.AddClaim(claim);
            }

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(_signatureProvider.GetSecretInBytes()), SecurityAlgorithms.HmacSha256Signature);

            var expDateTime = DateTime.UtcNow.AddHours(_jwtHelperConfiguration.TokenExpiryInHours);
            
            var jwtToken = jwtSecurityTokenHandler.CreateJwtSecurityToken(
                _jwtHelperConfiguration.SystemIdentityProviderIssuerValue,
                _jwtHelperConfiguration.SystemServicesAudienceValue,
                subject,
                DateTime.UtcNow,
                expDateTime,
                DateTime.UtcNow,
                signingCredentials);
            var tokenString = jwtToken.EncodedHeader + "." + jwtToken.EncodedPayload + "." + jwtToken.RawSignature;

            return new JwtTokenModel
            {
                Jwt = tokenString,
                JwtExpiryDateTime = expDateTime.ToString(CultureInfo.InvariantCulture)
            };
        }

        public ClaimsPrincipal DecodeToken(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            if (string.IsNullOrEmpty(token))
                return null;

            var validationParameters = new TokenValidationParameters
            {
                ValidAudience = _jwtHelperConfiguration.SystemServicesAudienceValue,
                ValidIssuer = _jwtHelperConfiguration.SystemIdentityProviderIssuerValue,
                IssuerSigningKeys = new List<SecurityKey>
                {
                    new SymmetricSecurityKey(_signatureProvider.GetSecretInBytes())
                }
            };

            SecurityToken secureToken = null;

            return jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out secureToken);

        }

        public IEnumerable<Claim> DecodeTokenWithOutValidation(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            if (string.IsNullOrEmpty(token))
                return null;

            var jwtsecureToken = jwtSecurityTokenHandler.ReadToken(token) as JwtSecurityToken;
            return jwtsecureToken?.Claims;
        }

        public bool ValidateTokenFormat(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            return jwtSecurityTokenHandler.CanReadToken(token);
        }
    }
}
