using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleJWTBasedAPI.Utilities.Interfaces
{
    public interface IEmailHandler
    {
        Task<bool> SendMail(IDictionary<string, object> parameters);
    }
}
