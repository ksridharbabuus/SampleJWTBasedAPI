using System.Collections.Generic;
using System.Security.Claims;
using SampleJWTBasedAPI.Models.Jwt;

namespace SampleJWTBasedAPI.Utilities.Interfaces
{
    public interface IJwtHelper
    {
        IJwtHelperConfiguration JwtHelperConfiguration { get; }

        JwtTokenModel CreateJwtToken(IEnumerable<Claim> claims);

        ClaimsPrincipal DecodeToken(string token);

        IEnumerable<Claim> DecodeTokenWithOutValidation(string token);

        bool ValidateTokenFormat(string token);
    }
}
