namespace SampleJWTBasedAPI.Utilities.Interfaces
{
    public interface IJwtHelperConfiguration
    {
        string UserId { get; }
        string UserEmail { get; }
        string UserAccount { get; }
        string SystemIdentityProviderIssuerValue { get; }
        string SystemServicesAudienceValue { get; }
        string TokenExpiryDttm { get; }
        int TokenExpiryInHours { get; }
    }
}
