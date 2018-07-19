using System.IdentityModel.Tokens;
using System.Text;
using SampleJWTBasedAPI.Utilities.Interfaces;

namespace SampleJWTBasedAPI.Utilities
{
    public class SignatureProvider : ISignatureProvider
    {
        public SecurityKey GetPublicKey()
        {
            return new InMemorySymmetricSecurityKey(GetSecretInBytes());
        }

        public byte[] GetSecretInBytes()
        {
            return Encoding.UTF8.GetBytes("FC6DBAF0-307C-4F41-B878-977563A25930");
        }
    }
}
