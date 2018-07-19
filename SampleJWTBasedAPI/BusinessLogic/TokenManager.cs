using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
//using SampleJWTBasedAPI.Datastore.Interfaces;
//using SampleJWTBasedAPI.Models.Exceptions;
using SampleJWTBasedAPI.Models.Jwt;
using SampleJWTBasedAPI.Models.User;
using SampleJWTBasedAPI.Models.Exceptions;
using SampleJWTBasedAPI.Utilities;
using SampleJWTBasedAPI.Utilities.Interfaces;
using SampleJWTBasedAPI.Datastore.Interfaces;

namespace SampleJWTBasedAPI.BusinessLogic
{
    public class TokenManager
    {
        private readonly IUserOperations _userOperations;
        private readonly IJwtHelper _jwtHelper;

        public TokenManager(IUserOperations userOperations, IJwtHelper jwtHelper)
        {
            _userOperations = userOperations;
            _jwtHelper = jwtHelper;
        }

        public async Task<JwtTokenModel> GenerateJwtToken(User userDetails)
        {
            if (string.IsNullOrWhiteSpace(userDetails.UserEmail) || string.IsNullOrWhiteSpace(userDetails.UserAccount))
                throw new ArgumentException("Missing important details");


            // Needs to get the User Object from the Database and use the same for creating the Claims/Token
            // As Shown below

            //var users = await _userOperations.GetUsersByEmail(userDetails.UserEmail).ConfigureAwait(false);
            //var user = users.FirstOrDefault(x => x.UserAccount.Equals(userDetails.UserAccount, StringComparison.InvariantCultureIgnoreCase));
            //if(user == null)
            //    throw new ClaimsException("User email and account mismatch");
            //if(!user.UserEmailVerified)
            //    throw new ClaimsException("User not verified");

            // For now using the same parameter as user object from DB... We need to remove it

            var user = userDetails;

            var claims = new List<Claim>
            {
                new Claim(ClaimsConstants.UserEmail, user.UserEmail),
                new Claim(ClaimsConstants.UserAccountAddess, user.UserAccount),
                new Claim(ClaimsConstants.UserId, user.UserId.ToString()),
                new Claim(ClaimsConstants.UserRole, user.UserRole ?? ""),
                new Claim(ClaimsConstants.UserEmailVerified, user.UserEmailVerified.ToString())
            };
            return _jwtHelper.CreateJwtToken(claims);
        }
    }
}
