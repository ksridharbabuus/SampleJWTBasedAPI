using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using SampleJWTBasedAPI.BusinessLogic;
using SampleJWTBasedAPI.Models.User;
using SampleJWTBasedAPI.Models.Jwt;
using SampleJWTBasedAPI.Security.Authorization;

namespace SampleJWTBasedAPI.Controllers
{

    [RoutePrefix("api/incident")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AuthorizeUser]
    public class IncidentController : ApiController
    {
        // GET: api/Incident
        public IEnumerable<string> Get()
        {
            // To execute this method successfully we need to pass "Token" with jwt value in the header

            // If you get this return value means you have Authorization to the request

            // do all the business logic by calling Business Logic Class for this Controller

            return new string[] { "value1", "value2" };
        }


    }
}
