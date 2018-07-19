using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleJWTBasedAPI.Datastore.Interfaces;
using SampleJWTBasedAPI.Models.User;

namespace SampleJWTBasedAPI.Datastore.Sql
{
    public class UserOperations : IUserOperations
    {
        //private readonly DbContext _dbContext;

        public UserOperations() //DbContext dbContext
        {
            //_dbContext = dbContext;
        }
        
        public async Task<User> CreateUser(User user)
        {
            //var existingUser = _dbContext.Users.FirstOrDefault(x =>
            //    x.UserEmail.Equals(user.UserEmail, StringComparison.InvariantCultureIgnoreCase));
            //if(existingUser != null && existingUser.UserAccount.Equals(user.UserAccount))
            //    throw new ArgumentException("User already exists");
            //var existingUserAccount = _dbContext.Users.FirstOrDefault(x => x.UserAccount.Equals(user.UserAccount, StringComparison.InvariantCultureIgnoreCase));
            //if(existingUserAccount != null)
            //    throw new ArgumentException("User account already mapped");
            //var savedUser = _dbContext.Users.Add(user);
            //await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            //return savedUser;

            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
            //_dbContext.Entry(user).State = EntityState.Modified;
            //await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            //return user;

            return null;
        }

        public async Task<User> DeleteUser(User user)
        {
            //_dbContext.Entry(user).State = EntityState.Deleted;
            //await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            //return user;

            return null;
        }

        public async Task<User> GetUser(int userId)
        {
            //var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            //return user;

            return null;
        }

        public async Task<IEnumerable<User>> GetUsersByEmail(string userEmail)
        {
            //var user = _dbContext.Users.Where(x => x.UserEmail.Equals(userEmail));
            //return user;

            return null;
        }

        public async Task<IEnumerable<User>> GetUsersByUserAccount(string userAccount)
        {
            //var user = _dbContext.Users.Where(x => x.UserAccount.Equals(userAccount));
            //return user;
            return null;
        }

        public async Task<User> CreateOrUpdateUserVerification(string userEmail, string userAccount, string userHash)
        {
            //var existingUser = _dbContext.Users.FirstOrDefault(x =>
            //    x.UserEmail.Equals(userEmail, StringComparison.InvariantCultureIgnoreCase) && x.UserAccount.Equals(userAccount));
            //if(existingUser == null)
            //    throw new ArgumentException($"User with {userEmail} does not exist");
            //var existingUserVerification = _dbContext.UserEmailVerifications.FirstOrDefault(x =>
            //    x.UserEmail.Equals(userEmail, StringComparison.InvariantCultureIgnoreCase) && x.UserAccount.Equals(userAccount));
            //if (existingUserVerification == null)
            //{
            //    _dbContext.UserEmailVerifications.Add(new UserEmailVerification
            //    {
            //        UserEmail = userEmail.ToLowerInvariant(),
            //        UserVerificationHash = userHash,
            //        UserAccount = userAccount
            //    });
            //    await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            //    return existingUser;
            //}
            //existingUserVerification.UserVerificationHash = userHash;
            //_dbContext.Entry(existingUserVerification).State = EntityState.Modified;
            //await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            //return existingUser;

            return null;
        }

        public async Task<User> VerifyUser(string userEmail, string userAccount, string userHash)
        {
            //var existingUser = _dbContext.Users.FirstOrDefault(x =>
            //    x.UserEmail.Equals(userEmail, StringComparison.InvariantCultureIgnoreCase) && x.UserAccount.Equals(userAccount, StringComparison.InvariantCultureIgnoreCase));
            //if (existingUser == null)
            //    throw new ArgumentException($"User with {userEmail} does not exist");
            //var existingUserVerification = _dbContext.UserEmailVerifications.FirstOrDefault(x =>
            //    x.UserEmail.Equals(userEmail, StringComparison.InvariantCultureIgnoreCase) &&
            //    x.UserVerificationHash.Equals(userHash) && x.UserAccount.Equals(userAccount, StringComparison.InvariantCultureIgnoreCase));
            //if(existingUserVerification == null)
            //    throw new ArgumentException("Invalid verification details supplied");
            //existingUser.UserEmailVerified = true;
            //_dbContext.Entry(existingUser).State = EntityState.Modified;
            //_dbContext.Entry(existingUserVerification).State = EntityState.Deleted;
            //await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            //return existingUser;

            return null;
        }
    }
}
