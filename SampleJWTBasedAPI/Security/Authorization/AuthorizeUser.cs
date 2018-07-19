using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using SampleJWTBasedAPI.Models.Jwt;
using SampleJWTBasedAPI.Utilities.Interfaces;

namespace SampleJWTBasedAPI.Security.Authorization
{
    public class AuthorizeUser : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var token = ExtractHeaderValue(actionContext, "Token");
            if (string.IsNullOrWhiteSpace(token))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    ReasonPhrase = "Missing Token header"
                };
                return false;
            }
            
            var jwtHelper = actionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(IJwtHelper)) as IJwtHelper;
            if (jwtHelper == null || !jwtHelper.ValidateTokenFormat(token))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    ReasonPhrase = "Invalid token format"
                };
                return false;
            }
            var principal = jwtHelper.DecodeToken(token);
            var claims = principal.Claims;
            var userAccount = claims.FirstOrDefault(x => x.Type.Equals(ClaimsConstants.UserAccountAddess))?.Value;
            var userId = claims.FirstOrDefault(x => x.Type.Equals(ClaimsConstants.UserId))?.Value;
            //var userEmailVerified = claims.FirstOrDefault(x => x.Type.Equals(ClaimsConstants.UserEmailVerified))?.Value;
            var userEmail = claims.FirstOrDefault(x => x.Type.Equals(ClaimsConstants.UserEmail))?.Value;

            if (string.IsNullOrWhiteSpace(userAccount) || string.IsNullOrWhiteSpace(userId) ||
                string.IsNullOrWhiteSpace(userEmail)) //|| string.IsNullOrWhiteSpace(userEmailVerified)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    ReasonPhrase = "Missing authorization details"
                };
                return false;
            }
            // This logic is not needed for us
            //bool.TryParse(userEmailVerified, out var emailVerified);
            //if (!emailVerified)
            //{
            //    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            //    {
            //        ReasonPhrase = "Email not verified"
            //    };
            //    return false;
            //}
            actionContext.RequestContext.Principal = principal;
            return true;
        }

        private string ExtractHeaderValue(HttpActionContext httpActionContext, string name)
        {
            IEnumerable<string> headerList;
            var result = httpActionContext.Request.Headers.TryGetValues(name, out headerList);
            return result ? headerList.First() : null;
        }
    }
}

