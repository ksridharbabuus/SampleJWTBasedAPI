using System;

namespace SampleJWTBasedAPI.Models.Exceptions
{
    public class ClaimsException : Exception
    {
        public ClaimsException(string message) : base(message)
        {
        }
    }
}
