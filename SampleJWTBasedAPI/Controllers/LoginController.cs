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

namespace SampleJWTBasedAPI.Controllers
{
    [RoutePrefix("api/login")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {

        private readonly TokenManager _tokenManager;

        public LoginController(TokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        [HttpGet]
        [Route("authenticate/{username}/{pwdhash}")]
        public async Task<JwtTokenModel> GetToken(string UserName, string PWDHash)
        {
            // Convert this Method as GetToken(Models.User.User userDetails)

            // Do all the User Validation by Connecting to Entity Model to Database and get the User Entity
            // For now hard coding the values...


            User testUser = new User();
            testUser.Name = "name1";
            testUser.UserAccount = "account1";
            testUser.UserEmail = "a@a.com";
            testUser.UserEmailVerified = true;
            testUser.UserId = 1;
            testUser.UserRole = "role1";

            // Create the JWT Token and Send it to Front End as shown below

            return await _tokenManager.GenerateJwtToken(testUser).ConfigureAwait(false);

        }

    }
}
