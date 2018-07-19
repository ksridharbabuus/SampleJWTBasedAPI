using System.IdentityModel.Tokens;

namespace SampleJWTBasedAPI.Utilities.Interfaces
{
    public interface ISignatureProvider
    {
        SecurityKey GetPublicKey();
        byte[] GetSecretInBytes();
    }
}
