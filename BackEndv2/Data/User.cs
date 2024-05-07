using Microsoft.AspNetCore.Identity;

namespace BackEndv2.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
