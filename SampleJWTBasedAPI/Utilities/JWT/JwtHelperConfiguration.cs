using SampleJWTBasedAPI.Utilities.Interfaces;

namespace SampleJWTBasedAPI.Utilities
{
    public class JwtHelperConfiguration : IJwtHelperConfiguration
    {
        public string UserId => "userid";
        public string UserEmail => "useremail";
        public string UserAccount => "useraccount";
        public string SystemIdentityProviderIssuerValue => "samplecompany";
        public string SystemServicesAudienceValue => "aud";
        public string TokenExpiryDttm => "exp";
        public int TokenExpiryInHours => 3600;
    }
}
