using System.Collections.Generic;
using System.Threading.Tasks;
using SampleJWTBasedAPI.Models.User;

namespace SampleJWTBasedAPI.Datastore.Interfaces
{
    public interface IUserOperations
    {
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(User user);
        Task<User> GetUser(int userId);
        Task<IEnumerable<User>> GetUsersByEmail(string userEmail);
        Task<IEnumerable<User>> GetUsersByUserAccount(string userAccount);
        Task<User> CreateOrUpdateUserVerification(string userEmail, string userAccount, string userHash);
        Task<User> VerifyUser(string userEmail, string userAccount, string userHash);
    }
}
