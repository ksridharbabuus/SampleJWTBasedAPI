using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SampleJWTBasedAPI.Models.User
{

    // This Entity Should be Generated either from Database or by Creating Entity Model

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public string UserAccount { get; set; }
        public bool UserEmailVerified { get; set; }
    }
}
